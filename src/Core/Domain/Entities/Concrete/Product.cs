using BasicECommerce.DAL.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicECommerce.DAL.Entities.Concrete
{
    public class Product : IEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string Name { get; set; }
        [Required]
        public Category Category { get; set; }
        [Required] 
        public Brand Brand { get; set; }
        [Required]
        public Color Color { get; set; }
        public string Feature { get; set; }
        public string Explanation { get; set; }
        [Required]
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
