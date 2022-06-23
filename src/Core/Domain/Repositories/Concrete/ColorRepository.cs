using BasicECommerce.DAL.Context.Concrete;
using BasicECommerce.DAL.Entities.Concrete;
using BasicECommerce.DAL.Repositories.Abstract;

namespace BasicECommerce.DAL.Repositories.Concrete
{
    public class ColorRepository : Repository<Color>, IColorRepository
    {
        public ColorRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
