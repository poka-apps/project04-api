using Project04.Domain.Enums;

namespace Project04.Domain.ValueObjects
{
    public record Password
    {
        public static string RegexPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_])[A-Za-z\d\W_]{8,}$";
        public string Value { get; private set; }

        private Password()
        { }

        public Password(string value)
        {
            value.ValidateRegex(RegexPattern);

            Value = value;
        }

        public static Password Generate()
        {
            var plainPassword = $"P@ssw0rd-{Guid.NewGuid()}";
            var password = new Password(plainPassword);

            return password;
        }

        public PasswordEncrypted Encrypt()
        {
            Hash(out var hash, out var salt);

            var passwordCrypted = new PasswordEncrypted(hash, salt);

            return passwordCrypted;
        }

        public bool IsValid(PasswordEncrypted passwordEncrypted)
        {
            #region Validations

            if (passwordEncrypted == null)
            {
                throw new AppException(AppErrorEnums.ValueRequired, nameof(passwordEncrypted));
            }

            #endregion

            using var hmac = new HMACSHA512(passwordEncrypted.Salt);
            var computerHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(Value));

            for (int i = 0; i < computerHash.Length; i++)
            {
                if (computerHash[i] != passwordEncrypted.Hash[i])
                {
                    return false;
                }
            }

            return true;
        }

        public void Hash(out byte[] hashValue, out byte[] saltValue)
        {
            using var hmac = new HMACSHA512();
            saltValue = hmac.Key;
            hashValue = hmac.ComputeHash(Encoding.UTF8.GetBytes(Value));
        }

        public override string ToString() => Value;
    }
}
