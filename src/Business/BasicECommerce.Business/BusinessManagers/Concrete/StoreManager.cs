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
    public class StoreManager : IStoreManager
    {
        // buraya mağazaya ürün ekleme eklenebilir.
        private readonly IStoreRepository _storeRepo;
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;

        public StoreManager(IStoreRepository storeRepo,
            IProductRepository productRepository, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _productRepository = productRepository;
            _storeRepo = storeRepo;
        }

        public async Task<BaseResponse> Add(StoreDTO model)
        {
            Product product = _productRepository.GetByIdAsync(model.ProductId).Result;
            User owner = _userRepository.GetByIdAsync(model.OwnerId).Result;

            EntityEntry<Store> result = await _storeRepo.Add(
                new Store
                {
                    Name = model.Name,
                    Product = new List<Product>() { product },
                    Owner = owner
                });

            BaseResponse response = new BaseResponse();
            response.IsSucces = result.State == EntityState.Added;
            if (response.IsSucces)
                response.Message = "Mağaza eklenmiştir.";
            else
                response.Message = "Mağaza eklenememiştir.";

            return response;
        }

        public async Task<BaseResponse> Delete(Guid id)
        {
            BaseResponse response = new BaseResponse();
            Store entity = await _storeRepo.GetByIdAsync(id);
            EntityEntry<Store> retVal = await _storeRepo.Delete(entity);
            response.IsSucces = retVal.State == EntityState.Deleted;
            response.Message = response.IsSucces ? "Silindi." : "Silinemedi";

            return response;
        }

        public async Task<ListDataResponse<Store>> Get(Expression<Func<Store, bool>> expression = null)
        {
            ListDataResponse<Store> response = new ListDataResponse<Store>();
            List<Store> stores = await _storeRepo.GetAsync(expression);

            response.Data = stores;
            response.IsSucces = stores != null;

            return response;
        }

        public async Task<DataResponse<Store>> GetById(Guid id)
        {
            DataResponse<Store> response = new DataResponse<Store>();
            Store store = await _storeRepo.GetByIdAsync(id);

            response.Data = store;
            response.IsSucces = store != null;

            return response;
        }

        public async Task<BaseResponse> Update(StoreDTO model, Guid id)
        {
            BaseResponse response = new BaseResponse();

            Product product = _productRepository.GetByIdAsync(model.ProductId).Result;
            User owner = _userRepository.GetByIdAsync(model.OwnerId).Result;

            EntityEntry<Store> res = await _storeRepo.Update(
                new Store
                {
                    Id = id,
                    Name = model.Name,
                    Owner = owner
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
