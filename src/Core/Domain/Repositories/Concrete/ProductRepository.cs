using BasicECommerce.DAL.Context.Concrete;
using BasicECommerce.DAL.Entities.Concrete;
using BasicECommerce.DAL.Repositories.Abstract;

namespace BasicECommerce.DAL.Repositories.Concrete
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
