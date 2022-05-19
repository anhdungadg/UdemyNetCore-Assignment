using Mango.Services.ProductAPI.Models.DTOs;

namespace Mango.Services.ProductAPI.Repository
{
    public interface IProductRepository
    {
        /// <summary>
        /// IEnumerable là kiểu list con mẹ gì đó lại quên mất rồi
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ProductDTO>> GetAllProducts();
        Task<ProductDTO> GetProductByID(int productId);
        Task<ProductDTO> CreateUpdateProduct(ProductDTO productDTO);
        Task<bool> DeleteProduct(int productId);
    }
}
