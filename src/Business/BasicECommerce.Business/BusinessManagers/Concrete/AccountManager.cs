using BasicECommerce.Business.BusinessManagers.Abstract;
using BasicECommerce.DAL;
using BasicECommerce.DAL.DTOs;
using BasicECommerce.DAL.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BasicECommerce.Business.BusinessManagers.Concrete
{
    public class AccountManager : IAccountManager
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;

        public AccountManager(UserManager<User> userManager
            , IConfiguration configuration, RoleManager<IdentityRole> roleManager
            , SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _configuration = configuration;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task<Response> Login(LoginDTO login)
        {
            Response retVal = new Response();

            List<Claim>? claims = new List<Claim>();
            User user = await _userManager.FindByEmailAsync(login.EMail);

            if (user != null)
            {
                bool result = await _signInManager.CanSignInAsync(user);

                if (result)
                //    result = await _userManager.CheckPasswordAsync(user, login.Password);
                //else
                {
                    await _signInManager.SignInAsync(user, result);
                    if (result)
                    {
                        var roles = await _userManager.GetRolesAsync(user);

                        if (roles.Any())
                        {
                            foreach (var role in roles)
                            {
                                claims.Add(new Claim(ClaimTypes.Role, role));
                            }

                            claims.Add(new Claim(type: ClaimTypes.Name, value: login.EMail));
                            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                        }

                        JwtSecurityToken token = null;

                        if (claims.Any())
                        {
                            token = GetToken(claims);
                        }
                        else
                        {
                            token = GetToken();
                        }

                        var handler = new JwtSecurityTokenHandler();
                        string jwt = handler.WriteToken(token);
                        result = true;

                        retVal.Message = jwt;
                        retVal.IsSucces = result;
                    }
                    retVal.Message = "Invalid Email or password";
                }
                else
                {
                    retVal.Message = "Invalid Email or password";
                }
            }
            else
            {
                retVal.Message = "Invalid Email or password";
            }

            return retVal;
        }

        private JwtSecurityToken GetToken(List<Claim> claims = null)
        {
            var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

            JwtSecurityToken token = null;

            if (claims != null)
            {
                token = new JwtSecurityToken(
                    signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256),
                    issuer: _configuration["JWT: Issuer"],
                    audience: _configuration["JWT: Audience"],
                    expires: DateTime.Now.AddDays(1),
                    claims: claims
                    );
            }
            else
            {
                token = new JwtSecurityToken(
                    signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256),
                    issuer: _configuration["JWT: Issuer"],
                    audience: _configuration["JWT: Audience"],
                    expires: DateTime.Now.AddDays(1)
                    );
            }
            return token;
        }
    }
}
