namespace Project04.Api.Infrastructure.DTOs
{
    public class TokenDTO
    {
        public string AccessToken { get; set; } = null!;
        public string? RefreshToken { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Type { get; set; } = "Bearer";
    }
}
