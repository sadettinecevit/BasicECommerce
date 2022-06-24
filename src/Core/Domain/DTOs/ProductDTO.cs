namespace BasicECommerce.DAL.DTOs
{
    public class ProductDTO
    {
        public string Name { get; set; }
        public Guid BrandId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid ColorId { get; set; }
        public string Explanation { get; set; }
        public string Feature { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
    }
}
