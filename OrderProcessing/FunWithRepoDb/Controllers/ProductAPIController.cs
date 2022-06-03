using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FunWithRepoDb.Models;
using FunWithRepoDb.Models.DTOs;
using FunWithRepoDb.Repository;


namespace FunWithRepoDb.Controllers
{
    [Route("api/[controller]/[action]")]
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
                _response.ErrorMessage = new List<string>() { ex.ToString() };
<<<<<<< HEAD
=======
            }

            return _response;
        }

        [HttpGet]
        public async Task<object> DoWhatEverYouWant()
        {
            try
            {
                _response.Result = await _productRepository.DoWhatEverYouWant();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
>>>>>>> 06d4721750cfa735cab54777d360bf867d935773
            }

            return _response;
        }
    }
}
