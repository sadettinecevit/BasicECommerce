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
    public class CartManager : ICartManager
    {
        private readonly ICartRepository _cartRepository;
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;
        public CartManager(ICartRepository cartRepository, IUserRepository userRepository,
            IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _userRepository = userRepository;
            _productRepository = productRepository;
        }

        public async Task<BaseResponse> Add(CartDTO model)
        {
            User user = await _userRepository.GetByIdAsync(model.UserId);
            Product product = await _productRepository.GetByIdAsync(model.ProductId);

            EntityEntry<Cart> result = await _cartRepository.Add(
                new Cart
                {
                    User = user,
                    Products = new List<Product>() { product }
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
            Cart entity = await _cartRepository.GetByIdAsync(id);
            EntityEntry<Cart> retVal = await _cartRepository.Delete(entity);
            response.IsSucces = retVal.State == EntityState.Deleted;
            response.Message = response.IsSucces ? "Silindi." : "Silinemedi";

            return response;
        }

        public async Task<ListDataResponse<Cart>> Get(Expression<Func<Cart, bool>> expression = null)
        {
            ListDataResponse<Cart> response = new ListDataResponse<Cart>();
            List<Cart> carts = await _cartRepository.GetAsync(expression);

            response.Data = carts;
            response.IsSucces = carts != null;

            return response;
        }

        public async Task<DataResponse<Cart>> GetById(Guid id)
        {
            DataResponse<Cart> response = new DataResponse<Cart>();
            Cart cart = await _cartRepository.GetByIdAsync(id);

            response.Data = cart;
            response.IsSucces = cart != null;

            return response;
        }

        public async Task<BaseResponse> Update(CartDTO model, Guid id)
        {
            BaseResponse response = new BaseResponse();

            User user = await _userRepository.GetByIdAsync(model.UserId);
            Product product = await _productRepository.GetByIdAsync(model.ProductId);
            
            //burası mantıklı olmadı ama revize edilecek.
            EntityEntry<Cart> res = await _cartRepository.Update(
                new Cart
                {
                    Id = id,
                    User = user,
                    Products = new List<Product>() { product }
                });

            response.IsSucces = res.State == EntityState.Modified;
            if (response.IsSucces)
                response.Message = "Sepet başarıyla güncellenmiştir.";
            else
                response.Message = "Sepet güncellenirken hata oluştu.";

            return response;
        }
    }
}
