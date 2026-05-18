using Project04.Domain.Enums;

namespace Project04.Domain.ValueObjects
{
    public record Email
    {
        public string Value { get; private set; }

        public Email(string value)
        {
            value.ValidateHasValue();

            Value = value
                        .ToLower()
                        .Trim();

            var isValid = default(bool);

            try
            {
                _ = new MailAddress(Value);

                isValid = true;
            }
            catch { }

            if (!isValid)
            {
                throw new AppException(AppErrorEnums.InvalidEmailFormat, value);
            }
        }

        public override string ToString() => this.Value;
    }
}
