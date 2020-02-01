using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Core3Layers.Core.Interfaces;

namespace Core3Layers.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly IRepositoryWrapper _rw;

        public UserService(IOptions<AppSettings> appSettings, IRepositoryWrapper rw)
        {
            _appSettings = appSettings.Value;
            _rw = rw;
        }

        //public async Task Register(Users user)
        //{
        //    await _rw.Users.CreateUser(user);
        //    user.UserRoles.Add(new UserRoles { UserId = user.Id, RoleId = StaticRoles.Customer });
        //    await _rw.Users.UpdateUserAsync(user);
        //}

        //public async Task<UserAuthModel> Login(string username, string password)
        //{
        //    var user = await _rw.Users.GetUserAuthenticateAsync(username, password);
        //    // return null if user not found
        //    if (user == null)
        //        return null;

        //    // authentication successful so generate jwt token
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Expires = DateTime.UtcNow.AddDays(30),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //    };
        //    // resolve claims
        //    var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
        //    identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
        //    identity.AddClaim(new Claim(ClaimTypes.Name, user.Id.ToString()));

        //    foreach (var role in user.UserRoles)
        //    {
        //        identity.AddClaim(new Claim(ClaimTypes.Role, role.RoleId));
        //    }

        //    tokenDescriptor.Subject = new ClaimsIdentity(identity);
        //    var token = tokenHandler.CreateToken(tokenDescriptor);

        //    var resultUser = _mapper.Map<Users, UserAuthModel>(user);
        //    resultUser.Token = tokenHandler.WriteToken(token);

        //    return resultUser;
        //}

        public string Authentication()
        {
            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Role, StaticRoles.Default)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
