using FunWithRepoDb.Models.DTOs;

namespace FunWithRepoDb.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDTO>> GetAll();
        Task<ProductDTO> GetById(int id);
    }
}
