using BasicECommerce.DAL.DTOs;
using BasicECommerce.DAL.Entities.Concrete;
using BasicECommerce.DAL.Response;
using System.Linq.Expressions;

namespace BasicECommerce.Business.BusinessManagers.Abstract
{
    public interface IStoreManager
    {
        public Task<BaseResponse> Add(StoreDTO model);
        public Task<BaseResponse> Update(StoreDTO model, Guid id);
        public Task<BaseResponse> Delete(Guid id);
        public Task<ListDataResponse<Store>> Get(Expression<Func<Store, bool>> expression = null);
        public Task<DataResponse<Store>> GetById(Guid id);
    }
 
}
