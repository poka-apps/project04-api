namespace Project04.Extensions
{
    public static class ObjectExtensions
    {
        public static bool IsNotNull(this object value) => value is not null;

        public static bool IsNull(this object value) => value is null;

        public static string ToJsonSerialized(this object value, Formatting formatting = Formatting.None) => 
            JsonConvert.SerializeObject(value, formatting);
    }
}
