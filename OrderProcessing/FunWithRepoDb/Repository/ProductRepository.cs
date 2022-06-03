using FunWithRepoDb.Models;
using FunWithRepoDb.Models.DTOs;
using FunWithRepoDb.Repository;
using Microsoft.Data.SqlClient;
using RepoDb;
using FunWithRepoDb.Infrastructure;

namespace FunWithRepoDb.Repository
{
    /// <summary>
    /// Repository là chỗ này sẽ đụng vô DbContext để lấy data lên
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString;
        private AutoMapper.IMapper _mapper;

        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
            //_mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetAll()
        {

            IEnumerable<ProductDTO> result = null;
            var sql = "SELECT * FROM [MangoProductAPI].[dbo].[Products];";
            
            using (var connection = new SqlConnection(_connectionString))
            {
                result = connection.ExecuteQuery<ProductDTO>(sql);
                /* Do the stuffs for the people here */
            }

            return result;
        }

        public async Task<ProductDTO> CreateAndUpdate(ProductDTO productDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductDTO> GetById(int id)
        {
            var param = new { Id = id };
            ProductDTO result = null;

            //using (var conn = new SqlConnection(_connectionString))
            //{
            //    result = conn.ExecuteQuery<ProductDTO>("GetProductByID", param, System.Data.CommandType.StoredProcedure).FirstOrDefault();
            //}

            // Use with SQL Stored Procedures
            //result = ApplicationDbContext.ExecuteQuery<ProductDTO>("GetProductByID", param, System.Data.CommandType.StoredProcedure).FirstOrDefault();


            // Use with SQL command, not yet completed
            //result = ApplicationDbContext.ExecuteQuery<ProductDTO>("SELECT * FROM [MangoProductAPI].[dbo].[Products] WHERE Id=@Id", param, System.Data.CommandType.Text).FirstOrDefault();

            // I don't know what this name, but look like Entity Framework
            using (var conn = new SqlConnection(_connectionString))
            {
                result = conn.Query("[dbo].[Products]", 2).FirstOrDefault();
            }

            return result;
        }
        
        public async Task<object> DoWhatEverYouWant()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                return conn.ExecuteNonQuery("insert into [MangoProductAPI].[dbo].[Products] (Name, ImageUrl, Price, Description, CategoryName) VALUES ('Test1', '', 0, 'Ahuhu', 'DKM')");
            }
        }
    }
}
