namespace E_Commerce_API.Dtos.Product
{
    public class ProductResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public int StoreId { get; set; }
    }
}
