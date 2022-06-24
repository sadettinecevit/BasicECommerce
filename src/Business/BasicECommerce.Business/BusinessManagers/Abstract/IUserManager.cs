using BasicECommerce.DAL.DTOs;
using BasicECommerce.DAL.Entities.Concrete;
using BasicECommerce.DAL.Response;
using System.Linq.Expressions;

namespace BasicECommerce.Business.BusinessManagers.Abstract
{
    public interface IUserManager
    {
        //Register
        //public Task<Response> Add(StoreDTO model);
        public Task<BaseResponse> Update(UserDTO model, Guid id);
        //Kullanıcı silinemez.
        //public Task<Response> Delete(StoreDTO model);
        public Task<ListDataResponse<User>> Get(Expression<Func<User, bool>> expression = null);
        public Task<DataResponse<User>> GetById(Guid id);
    }
 
}
