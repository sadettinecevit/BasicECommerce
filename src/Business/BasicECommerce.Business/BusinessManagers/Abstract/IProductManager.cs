using BasicECommerce.DAL.DTOs;
using BasicECommerce.DAL.Entities.Concrete;
using BasicECommerce.DAL.Response;
using System.Linq.Expressions;

namespace BasicECommerce.Business.BusinessManagers.Abstract
{
    public interface IProductManager
    {
        public Task<BaseResponse> Add(ProductDTO model);
        public Task<BaseResponse> Update(ProductDTO productDTO, Guid id);
        public Task<BaseResponse> Delete(Guid id);
        public Task<ListDataResponse<Product>> Get(Expression<Func<Product, bool>> expression = null);
        public Task<DataResponse<Product>> GetById(Guid id);
    }
 
}
