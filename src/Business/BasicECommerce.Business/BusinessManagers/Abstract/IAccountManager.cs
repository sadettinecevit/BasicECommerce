using BasicECommerce.DAL.DTOs;
using BasicECommerce.DAL.Response;

namespace BasicECommerce.Business.BusinessManagers.Abstract
{
    public interface IAccountManager
    {
        public Task<BaseResponse> Login(LoginDTO login);
        public Task<BaseResponse> Register(RegisterDTO login);
    }
 
}
