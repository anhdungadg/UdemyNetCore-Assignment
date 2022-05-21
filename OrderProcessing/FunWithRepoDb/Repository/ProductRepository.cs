using FunWithRepoDb.Models.DTOs;
using FunWithRepoDb.Repository;

namespace FunWithRepoDb.Repository
{
    /// <summary>
    /// Repository là chỗ này sẽ đụng vô DbContext để lấy data lên
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            
        }

        Task<ProductDTO> IProductRepository.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
