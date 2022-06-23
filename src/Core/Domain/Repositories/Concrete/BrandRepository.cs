using BasicECommerce.DAL.Context.Concrete;
using BasicECommerce.DAL.Entities.Concrete;
using BasicECommerce.DAL.Repositories.Abstract;

namespace BasicECommerce.DAL.Repositories.Concrete
{
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        public BrandRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
