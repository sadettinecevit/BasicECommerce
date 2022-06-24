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
    public class BrandManager : IBrandManager
    {
        private readonly IBrandRepository _brandRepository;

        public BrandManager(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<BaseResponse> Add(BrandDTO model)
        {
            EntityEntry<Brand> result = await _brandRepository.Add(
                new Brand
                {
                    Name = model.Name
                });

            BaseResponse response = new BaseResponse();
            response.IsSucces = result.State == EntityState.Added;
            if (response.IsSucces)
                response.Message = "Sepet oluşturulmuştur.";
            else
                response.Message = "Sepet olşturulamamıştır.";

            return response;
        }

        public async Task<BaseResponse> Delete(Guid id)
        {
            BaseResponse response = new BaseResponse();
            Brand entity = await _brandRepository.GetByIdAsync(id);
            EntityEntry<Brand> retVal = await _brandRepository.Delete(entity);
            response.IsSucces = retVal.State == EntityState.Deleted;
            response.Message = response.IsSucces ? "Silindi." : "Silinemedi";

            return response;
        }

        public async Task<ListDataResponse<Brand>> Get(Expression<Func<Brand, bool>> expression = null)
        {
            ListDataResponse<Brand> response = new ListDataResponse<Brand>();
            List<Brand> brands = await _brandRepository.GetAsync(expression);

            response.Data = brands;
            response.IsSucces = brands != null;

            return response;
        }

        public async Task<DataResponse<Brand>> GetById(Guid id)
        {
            DataResponse<Brand> response = new DataResponse<Brand>();
            Brand brand = await _brandRepository.GetByIdAsync(id);

            response.Data = brand;
            response.IsSucces = brand != null;

            return response;
        }

        public async Task<BaseResponse> Update(BrandDTO model, Guid id)
        {
            BaseResponse response = new BaseResponse();

            //burası mantıklı olmadı ama revize edilecek.
            EntityEntry<Brand> res = await _brandRepository.Update(
                new Brand
                {
                    Id = id,
                    Name = model.Name
                });

            response.IsSucces = res.State == EntityState.Modified;
            if (response.IsSucces)
                response.Message = "Marka başarıyla güncellenmiştir.";
            else
                response.Message = "Marka güncellenirken hata oluştu.";

            return response;
        }
    }
}
