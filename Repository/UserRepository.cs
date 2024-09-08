using MagicVilla.Data;
using MagicVilla.Model;
using MagicVilla.Model.Dto;
using MagicVilla.Repository.IRepository;
using MagicVilla_Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MagicVilla.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;
        private string secretKey;

        public UserRepository(ApplicationDbContext db, IConfiguration configuration)
        {
            _db = db;
            secretKey = configuration.GetValue<string>("ApiSettings:Secret");
        }

        public bool IsUniqueUser(string username)
        {
            var user = _db.localUsers.FirstOrDefault(x => x.UserName == username);
            if (user == null)
            {
                return true;
            }
            return false;
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            var user = _db.localUsers
                .FirstOrDefault(u => u.UserName.ToLower() == loginRequestDto.UserName.ToLower());

           


            if (user == null )
            {
                return new LoginResponseDto()
                {
                    Token = "",
                    User = null
                };
            }

            //if user was found generate JWT Token
            
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            LoginResponseDto loginResponseDto = new LoginResponseDto()
            {
                Token = tokenHandler.WriteToken(token),
                User = user

            };
            return loginResponseDto;
        }

        public async Task<LocalUser> Register(RegisterationRequestDto registerationRequestDto)
        {
            LocalUser user = new LocalUser()
            {
                UserName = registerationRequestDto.UserName,
                Password = registerationRequestDto.Password,
                Name = registerationRequestDto.Name,
                Role = registerationRequestDto.Role,
            };
            _db.localUsers.Add(user);
            await _db.SaveChangesAsync();
            user.Password = "";
            return user;
        }
    }
}
