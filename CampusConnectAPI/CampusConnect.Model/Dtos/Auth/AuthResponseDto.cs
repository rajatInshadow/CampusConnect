namespace CampusConnect.Model.Dtos.Auth
{
    public class AuthResponseDto
    {
        public string Token { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

        public DateTime Expiration { get; set; }
    }
}
