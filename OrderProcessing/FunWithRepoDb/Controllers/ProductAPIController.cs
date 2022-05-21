using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FunWithRepoDb.Models;
using FunWithRepoDb.Models.DTOs;
using FunWithRepoDb.Repository;


namespace FunWithRepoDb.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        protected ResponseDTO _response;
        private IProductRepository _productRepository;


        public ProductAPIController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _response = new ResponseDTO();
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                _response.Result = await _productRepository.GetAll();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string>() { ex.Message.ToString() };
            }

            return _response;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<object> GetById(int id)
        {
            try
            {
                _response.Result = await _productRepository.GetById(id);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string>() { ex.Message.ToString() };
            }

            return _response;
        }
    }
}
