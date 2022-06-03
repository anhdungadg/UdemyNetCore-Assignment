using Mango.Web.Models;
using Mango.Web.Services.IServices;

namespace Mango.Web.Services
{
    public class ProductService : BaseService, IProductService
    {
        public Task<T> CreateProductAsync<T>(ProductDTO productDTO)
        {
            throw new NotImplementedException();
        }

        public Task<T> DeleteProductAsync<T>(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAllProductsAsync<T>()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetProductByIdAsync<T>(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateProductAsync<T>(ProductDTO productDTO)
        {
            throw new NotImplementedException();
        }
    }
}
