using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using win1_api.DBContexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using win1_api.Models;
using Newtonsoft.Json.Linq;  
using win1_api.Authenticate;
using win1_api.Helpers;
using win1_api.Authentication;

  
namespace win1_api.Controllers  
{  
    // get all users
    [Route("/users")] 
    [ApiController]  
    public class UserController : ControllerBase  
    {  
        private MyDBContext myDbContext;  
  
        public UserController(MyDBContext context)  
        {  
            myDbContext = context;  
        }  
        public IList<Users> Get()  
        {  
            return (this.myDbContext.Users.ToList());  
        }  
    }

    // get user by id
    [Route("users/{id}")]
    public class testController : ControllerBase  
    { 
        private MyDBContext myDbContext;  
        public testController(MyDBContext context)  
        {  
            myDbContext = context;  
        }  

        public IList<Users> Get(int? id)
        {
            var test = this.myDbContext.Users.Where(e => e.Id == id.Value).ToList();
        
            return(test);
        }
    }
    [Route("users/create")]
    public class postController : ControllerBase  
    { 
        private MyDBContext myDbContext;

        public postController(MyDBContext context)  
        {  
            myDbContext = context;  
        }  
        [HttpPost]
        public IActionResult Post(string email, string password, string role)
        {
            var myRegex = new StringVerifications();

            var user = new Users
            {
                email = email,
                Password = myRegex.StringToSha256(password),
                Role = role
            };
            myDbContext.Users.Add(user);
            myDbContext.SaveChanges();
            return new CreatedResult("post", user);
        }
    }
     [Route("users/update/{id}")]
    public class updateController : ControllerBase  
    { 
        private MyDBContext myDbContext;

        public updateController(MyDBContext context)  
        {  
            myDbContext = context;  
        } 

    [HttpPut] 
    public IActionResult Put(int? Id,string email, string password, string role)
    {
        var user = this.myDbContext.Users.Where(e => e.Id == Id.Value).ToList();

        var myRegex = new StringVerifications();
        
        foreach (Users _user in user){ 
        _user.email = email;
        _user.Role = role;
        _user.Password = myRegex.StringToSha256(password);
        }
            myDbContext.SaveChanges();
            return new CreatedResult("post", user);
        }
    }

    [Route("users/delete/{id}")]
    public class deleteController : ControllerBase  
    { 
        private MyDBContext myDbContext;  
        public deleteController(MyDBContext context)  
        {  
            myDbContext = context;  
        }  
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var user = this.myDbContext.Users.Where(e => e.Id == id.Value).ToList();

             foreach (Users _user in user)
            { 
            myDbContext.Users.Remove(_user);
            }
            
            myDbContext.SaveChanges();

        
            return new CreatedResult("deleted",user);
            
        }
    }
    [Route("/users/authentificate")]
    
    public class AuthenticateController: ControllerBase
    {
       
        
        private readonly AppSettings _appSettings;

        private MyDBContext myDbContext;


        public AuthenticateController(MyDBContext context, IOptions<AppSettings> appSettings)
        {
            myDbContext = context;
            _appSettings = appSettings.Value;

        }
     
        [HttpPost]
        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var myRegex = new StringVerifications();
            var _user = this.myDbContext.Users.ToList();
            var user = _user.SingleOrDefault(x => x.email == model.email && x.Password == myRegex.StringToSha256(model.Password));

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token

            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }
        private string generateJwtToken(Users user)
        {
            // generate token that is valid for 7 days
            Console.WriteLine(_appSettings);
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


    }
}