using Project04.Domain.Enums;
using Project04.Domain;

namespace Project04.Extensions
{
    public static class ObjectExtensions
    {
        public static bool IsNotNull(this object value) => value is not null;

        public static bool IsNull(this object value) => value is null;

        public static void ValidateNotNull<TObject>(this TObject value)
            where TObject : class
        {
            if (value == null)
            {
                throw new AppException(AppErrorEnums.ValueRequired, nameof(value));
            }
        }

        public static string ToJsonSerialized(this object value, Formatting formatting = Formatting.None) => 
            JsonConvert.SerializeObject(value, formatting);
    }
}
