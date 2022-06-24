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
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;
        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ListDataResponse<User>> Get(Expression<Func<User, bool>> expression = null)
        {
            List<User> result = _userRepository.GetAsync(expression).Result;
            return new ListDataResponse<User>()
            {
                IsSucces = result != null,
                Data = result
            };
        }

        public async Task<DataResponse<User>> GetById(Guid id)
        {
            User user = await _userRepository.GetByIdAsync(id);
            return new DataResponse<User>()
            {
                Data = user,
                IsSucces = user != null
            };
        }

        public async Task<BaseResponse> Update(UserDTO model, Guid id)
        {
            BaseResponse response = new BaseResponse();
            EntityEntry<User> res = await _userRepository.Update(
                new User
                {
                    Id = id.ToString(),
                    Name = model.Name,
                    Lastname = model.LastName,
                    Email = model.EMail
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
