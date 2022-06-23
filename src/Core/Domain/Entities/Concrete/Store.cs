using BasicECommerce.DAL.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace BasicECommerce.DAL.Entities.Concrete
{
    public class Store : IEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string Name { get; set; }
        [Required]
        public User Owner { get; set; }
        [Required]
        public Product Product { get; set; }
    }
}
