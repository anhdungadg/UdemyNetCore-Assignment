namespace OrderProcessing.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new List<Product>();

        public ProductRepository()
        {
            _products.Add(new Product {
                Id = Guid.NewGuid(),
                Code = "P0001",
                Name = "Lenovo Laptoop 1",
                Quantity_In_Stock = 15,
                Unit_Price = 125000
            });

            _products.Add(new Product
            {
                Id = Guid.NewGuid(),
                Code = "P0002",
                Name = "Dell Surface Pro",
                Quantity_In_Stock = 25,
                Unit_Price = 135000
            });

            _products.Add(new Product
            {
                Id = Guid.NewGuid(),
                Code = "P0002",
                Name = "HP Laptop",
                Quantity_In_Stock = 20,
                Unit_Price = 115000
            });
        }

        public Task<List<Product>> GetAllProducts()
        {
            return Task.FromResult(_products);
        }
        
    }
    
}
