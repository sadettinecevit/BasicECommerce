using BasicECommerce.DAL;
using BasicECommerce.DAL.DTOs;

namespace BasicECommerce.Business.BusinessManagers.Abstract
{
    public interface IAccountManager
    {
        public Task<Response> Login(LoginDTO login);
/*
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
*/
    }
}
