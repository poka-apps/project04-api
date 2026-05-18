using Project04.Domain.Enums;
using Project04.Domain;

namespace Project04.Extensions
{
    public static class IEnumerableExtensions
    {
        public static void ValidateNotEmpty<T>(this IEnumerable<T> value)
        {
            #region Validations

            value.ValidateNotNull();

            #endregion

            if (value.Count() == 0)
            {
                throw new AppException(AppErrorEnums.ValueRequired, nameof(value));
            }
        }
    }
}
