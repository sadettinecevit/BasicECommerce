using BasicECommerce.DAL.Entities.Abstract;
using Microsoft.AspNetCore.Identity;

namespace BasicECommerce.DAL.Entities.Concrete
{
    public class User : IdentityUser, IEntity
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
    }
}
