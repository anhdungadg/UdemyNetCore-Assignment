using AutoMapper;
using Mango.Services.ProductAPI.Models.DTOs;
using Mango.Services.ProductAPI.Infrastructures;
using Microsoft.EntityFrameworkCore;
using Mango.Services.ProductAPI.Models;

namespace Mango.Services.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public ProductRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ProductDTO> CreateUpdateProduct(ProductDTO productDTO)
        {
            Product product = _mapper.Map<ProductDTO, Product>(productDTO);
            if (product.ProductId > 0)
            {
                _db.Products.Update(product);
            }
            else
            {
                _db.Products.Add(product);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Product, ProductDTO>(product);
        }
        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                Product product = await _db.Products.FirstOrDefaultAsync(x => x.ProductId == productId);
                if(product==null)
                {
                    return false;
                }
                _db.Products.Remove(product);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProducts()
        {
            List<Product> productList = await _db.Products.ToListAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(productList);
        }
        
        public async Task<ProductDTO> GetProductByID(int productId)
        {
            // Chỗ này trên course làm như comment bên dưới
            //Product product = await _db.Products.Where(x => x.ProductId == productId).FirstOrDefaultAsync();
            Product product = await _db.Products.Where<Product>(p => p.ProductId == productId).FirstOrDefaultAsync();
            return _mapper.Map<ProductDTO>(product);
        }
    }
}
