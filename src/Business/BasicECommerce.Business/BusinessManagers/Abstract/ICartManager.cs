using BasicECommerce.DAL.DTOs;
using BasicECommerce.DAL.Entities.Concrete;
using BasicECommerce.DAL.Response;
using System.Linq.Expressions;

namespace BasicECommerce.Business.BusinessManagers.Abstract
{
    public interface ICartManager
    {
        public Task<BaseResponse> Add(CartDTO model);
        public Task<BaseResponse> Update(CartDTO model, Guid id);
        public Task<BaseResponse> Delete(Guid id);
        public Task<ListDataResponse<Cart>> Get(Expression<Func<Cart, bool>> expression = null);
        public Task<DataResponse<Cart>> GetById(Guid id);
    }
 
}
