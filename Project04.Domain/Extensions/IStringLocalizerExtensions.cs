namespace Project04.Extensions
{
    public static class IStringLocalizerExtensions
    {
        public static string GetValue(this IStringLocalizer stringLocalizer, Enum @enum, params object[] args)
        {
            var defaultValue = $"{@enum} (Translation not yet implemented)";
            var key = $"{@enum.GetType().Name}_{Convert.ToInt32(@enum)}";
            var result = stringLocalizer[key]?.Value ?? defaultValue;

            if (result == key)
            {
                result = defaultValue;
            }

            result = string.Format(result, args);

            return result;
        }

        public static string GetValue(this IStringLocalizer stringLocalizer, Type type)
        {
            var key = type.Name;
            var result = stringLocalizer[key]?.Value ?? type.Name;

            return result;
        }

        public static string GetValue(this IStringLocalizer stringLocalizer, string typeName)
        {
            var result = stringLocalizer[typeName]?.Value ?? typeName;

            return result;
        }
    }
}
