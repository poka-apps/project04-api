namespace Project04.Domain.ValueObjects
{
    public record PasswordEncrypted
    {
        public byte[] Hash { get; private set; }
        public byte[] Salt { get; private set; }

        public PasswordEncrypted(byte[] hash, byte[] salt)
        {
            hash.ValidateNotEmpty();
            salt.ValidateNotEmpty();

            Hash = hash;
            Salt = salt;
        }
    }
}
