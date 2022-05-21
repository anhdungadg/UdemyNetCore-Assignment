namespace FunWithRepoDb.Models.DTOs
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public double Price { get; set; }
        public string Description { get; set; } = null!;
        public string CategoryName { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public string Ahihi { get; set; } = "Đây là DTO nhé!";
    }
}
