namespace win1_api.Models
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(Users user, string token)
        {
            Id = user.Id;
            email = user.email;
            Password = user.Password;
            Role = user.Role;
            Token = token;
        }
    }
}