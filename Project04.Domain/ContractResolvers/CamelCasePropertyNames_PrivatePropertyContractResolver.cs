namespace Project04.Domain.ContractResolvers
{
    public class CamelCasePropertyNames_PrivatePropertyContractResolver : CamelCasePropertyNamesContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var jsonProperty = base.CreateProperty(member, memberSerialization);

            if (jsonProperty.Writable == false)
            {
                var propertyInfo = member as PropertyInfo;
                var hasPrivateSetter = propertyInfo?.GetSetMethod(true) != null;

                jsonProperty.Writable = hasPrivateSetter;
            }

            return jsonProperty;
        }
    }
}
