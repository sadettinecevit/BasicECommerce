using BasicECommerce.DAL.Context.Concrete;
using BasicECommerce.DAL.Entities.Concrete;
using BasicECommerce.DAL.Repositories.Abstract;

namespace BasicECommerce.DAL.Repositories.Concrete
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
