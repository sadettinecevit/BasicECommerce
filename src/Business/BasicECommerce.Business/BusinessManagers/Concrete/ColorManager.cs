using BasicECommerce.Business.BusinessManagers.Abstract;
using BasicECommerce.DAL.DTOs;
using BasicECommerce.DAL.Entities.Concrete;
using BasicECommerce.DAL.Repositories.Abstract;
using BasicECommerce.DAL.Response;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace BasicECommerce.Business.BusinessManagers.Concrete
{
    public class ColorManager : IColorManager
    {
        private readonly IColorRepository _colorRepository;
        public ColorManager(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }

        public async Task<BaseResponse> Add(ColorDTO model)
        {
            EntityEntry<Color> result = await _colorRepository.Add(
                new Color
                {
                    Name = model.Name
                });

            BaseResponse response = new BaseResponse();
            response.IsSucces = result.State == EntityState.Added;
            if (response.IsSucces)
                response.Message = "Renk eklenmiştir.";
            else
                response.Message = "Renk eklenememiştir.";

            return response;
        }

        public async Task<BaseResponse> Delete(Guid id)
        {
            BaseResponse response = new BaseResponse();
            Color entity = await _colorRepository.GetByIdAsync(id);
            EntityEntry<Color> retVal = await _colorRepository.Delete(entity);
            response.IsSucces = retVal.State == EntityState.Deleted;
            response.Message = response.IsSucces ? "Silindi." : "Silinemedi";

            return response;
        }

        public async Task<ListDataResponse<Color>> Get(Expression<Func<Color, bool>> expression = null)
        {
            ListDataResponse<Color> response = new ListDataResponse<Color>();
            List<Color> colors = await _colorRepository.GetAsync(expression);

            response.Data = colors;
            response.IsSucces = colors != null;

            return response;
        }

        public async Task<DataResponse<Color>> GetById(Guid id)
        {
            DataResponse<Color> response = new DataResponse<Color>();
            Color color = await _colorRepository.GetByIdAsync(id);

            response.Data = color;
            response.IsSucces = color != null;

            return response;
        }

        public async Task<BaseResponse> Update(ColorDTO model, Guid id)
        {
            BaseResponse response = new BaseResponse();

            EntityEntry<Color> res = await _colorRepository.Update(
                new Color
                {
                    Id = id,
                    Name = model.Name
                });

            response.IsSucces = res.State == EntityState.Modified;
            if (response.IsSucces)
                response.Message = "Ürün başarıyla güncellenmiştir.";
            else
                response.Message = "Ürün güncellenirken hata oluştu.";

            return response;
        }
    }
}
