using BasicECommerce.DAL.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace BasicECommerce.DAL.Entities.Concrete
{
    public class Cart : IEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public User User { get; set; }
        [Required]
        public IEnumerable<Product> Products { get; set; }
    }
}
