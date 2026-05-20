using Project04.Domain.Enums;

namespace Project04.Domain.ValueObjects
{
    public record AccessToken
    {
        public string Value { get; private set; }
        public string? RefreshToken { get; private set; } = null;
        public DateTime? ExpirationDate { get; private set; }

        public AccessToken(string value, string? refreshToken = null, DateTime? expirationDate = null)
        {
            value.ValidateHasValue();

            ExpirationDate = expirationDate;
            RefreshToken = refreshToken;
            Value = value;
        }

        public void Validate() 
        {
            if (this.IsValid() == false)
            {
                throw new AppException(AppErrorEnums.ExpiredToken, this.Value);
            }
        }

        public void Invalidate()
        {
            this.ExpirationDate = DateTime.UtcNow;
        }

        public bool IsValid() => 
            this.ExpirationDate.HasValue 
                ? this.ExpirationDate > DateTime.UtcNow
                : true;
    }
}
