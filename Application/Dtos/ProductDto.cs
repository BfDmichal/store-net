namespace Application.Dtos
{
    public class ProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public int ProductCategoryId { get; set; }
        public string ProductCategory { get; set; }
    }
}
