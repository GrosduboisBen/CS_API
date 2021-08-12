using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using win1_api.Controllers;
// using win1_api.Regex;
using win1_api.Models;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using win1_api.Helpers;

namespace win1_api.Authenticate
{
    public class Authenticate {
        private readonly AppSettings _appSettings;

        public Authenticate( IOptions<AppSettings> appSettings)
        {
          
            _appSettings = appSettings.Value;
        }
    // private string generateJwtToken(Users user)
    //     {

    //         Console.WriteLine(_appSettings);
    //         // generate token that is valid for 7 days
    //         var tokenHandler = new JwtSecurityTokenHandler();
    //         var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
    //         var tokenDescriptor = new SecurityTokenDescriptor
    //         {
    //             Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
    //             Expires = DateTime.UtcNow.AddDays(7),
    //             SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
    //         };
    //         var token = tokenHandler.CreateToken(tokenDescriptor);
    //         return tokenHandler.WriteToken(token);
    //     }
    }
}