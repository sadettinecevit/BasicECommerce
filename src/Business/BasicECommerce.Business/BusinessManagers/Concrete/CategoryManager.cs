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
    public class CategoryManager : ICategoryManager
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<BaseResponse> Add(CategoryDTO model)
        {
            EntityEntry<Category> result = await _categoryRepository.Add(
                new Category
                {
                    Name = model.Name
                });

            BaseResponse response = new BaseResponse();
            response.IsSucces = result.State == EntityState.Added;
            if (response.IsSucces)
                response.Message = "Kategori eklenmiştir.";
            else
                response.Message = "Kategori eklenememiştir.";

            return response;
        }

        public async Task<BaseResponse> Delete(Guid id)
        {
            BaseResponse response = new BaseResponse();
            Category entity = await _categoryRepository.GetByIdAsync(id);
            EntityEntry<Category> retVal = await _categoryRepository.Delete(entity);
            response.IsSucces = retVal.State == EntityState.Deleted;
            response.Message = response.IsSucces ? "Silindi." : "Silinemedi";

            return response;
        }

        public async Task<ListDataResponse<Category>> Get(Expression<Func<Category, bool>> expression = null)
        {
            ListDataResponse<Category> response = new ListDataResponse<Category>();
            List<Category> category = await _categoryRepository.GetAsync(expression);

            response.Data = category;
            response.IsSucces = category != null;

            return response;
        }

        public async Task<DataResponse<Category>> GetById(Guid id)
        {
            DataResponse<Category> response = new DataResponse<Category>();
            Category category = await _categoryRepository.GetByIdAsync(id);

            response.Data = category;
            response.IsSucces = category != null;

            return response;
        }

        public async Task<BaseResponse> Update(CategoryDTO model, Guid id)
        {
            BaseResponse response = new BaseResponse();

            EntityEntry<Category> res = await _categoryRepository.Update(
                new Category
                {
                    Id = id,
                    Name = model.Name
                });

            response.IsSucces = res.State == EntityState.Modified;
            if (response.IsSucces)
                response.Message = "Kategori başarıyla güncellenmiştir.";
            else
                response.Message = "Kategori güncellenirken hata oluştu.";

            return response;
        }
    }
}
