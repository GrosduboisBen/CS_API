 
using System.ComponentModel.DataAnnotations;

namespace win1_api.Models
{
    public class AuthenticateRequest
    {
        [Required]
        public string email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}