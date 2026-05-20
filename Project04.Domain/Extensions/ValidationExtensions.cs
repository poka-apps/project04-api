using Project04.Domain;
using Project04.Domain.Enums;

namespace Project04.Extensions
{
    public static class ValidationExtensions
    {
        #region IEnumerable

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

        #endregion

        #region String

        /// <summary>
        /// Validate is not null and is not empty.
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="AppException"></exception>
        public static void ValidateHasValue(this string value)
        {
            if (value.HasValue() == false)
            {
                throw new AppException(AppErrorEnums.ValueRequired, nameof(value));
            }
        }

        public static void ValidateRegex(this string value, string pattern)
        {
            value.ValidateHasValue();

            pattern.ValidateHasValue();

            if (new Regex(pattern).IsMatch(value) == false)
            {
                throw new AppException(AppErrorEnums.InvalidRegexFormat, pattern, value);
            }
        }

        #endregion

        #region Object

        public static void ValidateNotNull<TObject>(this TObject value)
            where TObject : class
        {
            if (value == null)
            {
                throw new AppException(AppErrorEnums.ValueRequired, nameof(value));
            }
        }

        #endregion

        #region DateTime

        public static void ValidateGreaterThan(this DateTime value, DateTime _value)
        {
            if (value < _value)
            {
                throw new AppException(AppErrorEnums.ValueLowerOrEqual, value);
            }
        }

        #endregion
    }
}
