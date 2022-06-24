using BasicECommerce.DAL.DTOs;
using BasicECommerce.DAL.Entities.Concrete;
using BasicECommerce.DAL.Response;
using System.Linq.Expressions;

namespace BasicECommerce.Business.BusinessManagers.Abstract
{
    public interface IBrandManager
    {
        public Task<BaseResponse> Add(BrandDTO model);
        public Task<BaseResponse> Update(BrandDTO model, Guid id);
        public Task<BaseResponse> Delete(Guid id);
        public Task<ListDataResponse<Brand>> Get(Expression <Func<Brand, bool>> expression = null);
        public Task<DataResponse<Brand>> GetById(Guid id);
    }
 
}
