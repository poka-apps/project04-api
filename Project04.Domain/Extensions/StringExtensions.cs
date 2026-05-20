using Project04.Domain;
using Project04.Domain.Enums;
using Project04.Domain.ValueObjects;

namespace Project04.Extensions
{    
    public static class StringExtensions
    {
        public static byte[] ToUTF8Bytes(this string value) =>
            Encoding.UTF8.GetBytes(value);

        public static bool IsNullOrWhiteSpace(this string value) =>
            string.IsNullOrWhiteSpace(value);

        public static bool IsNullOrEmpty(this string value) =>
            string.IsNullOrEmpty(value);

        public static bool HasValue(this string value) =>
            !value.IsNullOrEmpty() && !value.IsNullOrWhiteSpace();

        public static TObjectId ToBaseEntityId<TObjectId>(this string value)
            where TObjectId : BaseEntityId => 
            value.ToObjectId<TObjectId, Guid>();

        public static TObjectId ToObjectId<TObjectId, TValue>(this string value)
            where TObjectId : BaseObjectId<TValue>
        {
            #region Validations

            value.ValidateHasValue();

            #endregion

            try
            {
                var type = typeof(TObjectId);
                var valueParts = value.Split('_');
                var objectIdType = valueParts[0];
                var objectIdValue = default(object);
                {
                    objectIdValue = string.Join('_', valueParts.ToList().Skip(1));

                    objectIdValue.ValidateNotNull();

                    if (typeof(TValue) == typeof(string))
                    {
                    }
                    else if (typeof(TValue) == typeof(int))
                    {
                        objectIdValue = int.Parse(objectIdValue.ToString()!);
                    }
                    else if (typeof(TValue) == typeof(Guid))
                    {
                        objectIdValue = Guid.Parse(objectIdValue.ToString()!);
                    }
                    else
                    {
                        throw new AppException(AppErrorEnums.NotImplemented, typeof(TValue).Name);
                    }

                }
                var result = (TObjectId)Activator.CreateInstance(type, objectIdValue)!;

                if (objectIdType.ToLower().Trim() != result.GetType_().ToLower())
                {
                    throw new AppException(AppErrorEnums.InvalidCast, value);
                }

                return result;
            }
            catch
            {
                throw new AppException(AppErrorEnums.InvalidCast, value);
            }
        }

        public static UserRoleEnums ToUserRoleEnums(this string value) =>
            UserRoleEnums.FromValue(value);

        public static Password ToPassword(this string value) => 
            new(value);

        public static Email ToEmail(this string value) => 
            new(value);

        public static Name ToName(this string value) => 
            new(value);
    }
}
