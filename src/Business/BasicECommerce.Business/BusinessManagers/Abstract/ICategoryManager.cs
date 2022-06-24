using BasicECommerce.DAL.DTOs;
using BasicECommerce.DAL.Entities.Concrete;
using BasicECommerce.DAL.Response;
using System.Linq.Expressions;

namespace BasicECommerce.Business.BusinessManagers.Abstract
{
    public interface ICategoryManager
    {
        public Task<BaseResponse> Add(CategoryDTO model);
        public Task<BaseResponse> Update(CategoryDTO model, Guid id);
        public Task<BaseResponse> Delete(Guid id);
        public Task<ListDataResponse<Category>> Get(Expression<Func<Category, bool>> expression = null);
        public Task<DataResponse<Category>> GetById(Guid id);
    }
 
}
