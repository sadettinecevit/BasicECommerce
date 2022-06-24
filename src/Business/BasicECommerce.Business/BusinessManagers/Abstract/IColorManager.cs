using BasicECommerce.DAL.DTOs;
using BasicECommerce.DAL.Entities.Concrete;
using BasicECommerce.DAL.Response;
using System.Linq.Expressions;

namespace BasicECommerce.Business.BusinessManagers.Abstract
{
    public interface IColorManager
    {
        public Task<BaseResponse> Add(ColorDTO model);
        public Task<BaseResponse> Update(ColorDTO model, Guid id);
        public Task<BaseResponse> Delete(Guid id);
        public Task<ListDataResponse<Color>> Get(Expression<Func<Color, bool>> expression = null);
        public Task<DataResponse<Color>> GetById(Guid id);
    }
 
}
