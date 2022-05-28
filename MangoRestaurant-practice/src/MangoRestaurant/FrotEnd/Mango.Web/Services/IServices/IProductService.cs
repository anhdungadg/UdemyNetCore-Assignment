using System.Threading.Tasks;
using Mango.Web.Models;


namespace Mango.Web.Services.IServices
{
    public interface IProductService
    {
        public Task<T> GetAllProductsAsync<T>();
        public Task<T> GetProductByIdAsync<T>(int id);
        public Task<T> CreateProductAsync<T>(ProductDTO productDTO);
        public Task<T> UpdateProductAsync<T>(ProductDTO productDTO);
        public Task<T> DeleteProductAsync<T>(int id);
    }
}
