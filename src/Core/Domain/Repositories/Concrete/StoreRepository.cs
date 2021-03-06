using BasicECommerce.DAL.Context.Concrete;
using BasicECommerce.DAL.Entities.Concrete;
using BasicECommerce.DAL.Repositories.Abstract;

namespace BasicECommerce.DAL.Repositories.Concrete
{
    public class StoreRepository : Repository<Store>, IStoreRepository
    {
        public StoreRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
