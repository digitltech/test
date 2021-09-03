using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Test.Core
{
    public class UserServices:IUserServices
    {
        private readonly IMongoCollection<User> users;
        private readonly string key;

        public UserServices(IDBClient dBClient)
        {
            users = dBClient.GetUsersCollection();

            this.key = "1234QWE";
        }

        public List<User> GetUsers()=> users.Find(users=>true).ToList();

        public User GetUser(string id) => users.Find(user => user.Id == id).First();

        public User Create (User user)
        {   
            users.InsertOne(user); 
            return user;
        }
        public string Authenticate(string name, string password)
        {
            var user = this.users.Find(x=>x.Name==name && x.Password==password).FirstOrDefault();

            if (user == null)
            {
                return null;
            }

            var TokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            var tokenDesxriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[] {
                new Claim(ClaimTypes.Name,name),
                }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = TokenHandler.CreateToken(tokenDesxriptor);
            return TokenHandler.WriteToken(token);

    }
    }

}

    
