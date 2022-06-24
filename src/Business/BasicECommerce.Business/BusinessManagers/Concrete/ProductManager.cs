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
    public class ProductManager : IProductManager
    {
        private readonly IProductRepository _repo;
        private readonly IBrandManager _brand;
        private readonly ICategoryManager _category;
        private readonly IColorManager _color;

        public ProductManager(IProductRepository repo, IBrandManager brand,
            ICategoryManager category, IColorManager color)
        {
            _repo = repo;
            _brand = brand;
            _category = category;
            _color = color;
        }

        public async Task<BaseResponse> Add(ProductDTO model)
        {
            BaseResponse response = new BaseResponse();
            EntityEntry<Product> res = await _repo.Add(
                new Product
                {
                    Name = model.Name,
                    Brand = _brand.GetById(model.BrandId).Result.Data,
                    Category = _category.GetById(model.CategoryId).Result.Data,
                    Color = _color.GetById(model.ColorId).Result.Data,
                    Explanation = model.Explanation,
                    Feature = model.Feature,
                    Stock = model.Stock,
                    Price = model.Price
                });

            response.IsSucces = res.State == EntityState.Added;
            if (response.IsSucces)
                response.Message = "Ürün başarıyla eklenmiştir.";
            else
                response.Message = "Ürün eklenirken hata oluştu.";

            return response;
        }

        public async Task<BaseResponse> Delete(Guid id)
        {
            BaseResponse response = new BaseResponse();

            Product model = await _repo.GetByIdAsync(id);

            EntityEntry<Product> res = await _repo.Delete(model);

            response.IsSucces = res.State == EntityState.Deleted;
            if (response.IsSucces)
                response.Message = "Ürün başarıyla silinmiştir.";
            else
                response.Message = "Ürün silinirken hata oluştu.";

            return response;
        }

        public async Task<ListDataResponse<Product>> Get(Expression<Func<Product, bool>> expression = null)
        {
            return new ListDataResponse<Product>()
            {
                IsSucces = true,
                Message = "Ürünler listelenmiştir.",
                Data = await _repo.GetAsync(expression)
            };
        }

        public async Task<DataResponse<Product>> GetById(Guid id)
        {

            Product data = _repo.GetByIdAsync(id).Result;

            return new DataResponse<Product>()
            {
                Data = data,
                IsSucces = data != null
            };
        }

        public async Task<BaseResponse> Update(ProductDTO model, Guid id)
        {
            BaseResponse response = new BaseResponse();
            EntityEntry<Product> res = await _repo.Update(
                new Product
                {
                    Id = id,
                    Name = model.Name,
                    Brand = _brand.GetById(model.BrandId).Result.Data,
                    Category = _category.GetById(model.CategoryId).Result.Data,
                    Color = _color.GetById(model.ColorId).Result.Data,
                    Explanation = model.Explanation,
                    Feature = model.Feature,
                    Stock = model.Stock,
                    Price = model.Price
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
