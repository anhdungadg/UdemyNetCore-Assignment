using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Helper;


namespace OrderProcessing.Customer.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;

        }

        //[HttpGet]
        //public async Task<ActionResult<List<Customer>>> GetAllCustomer()
        //{
        //    return await _customerRepository.GetAllCustomer();
        //}

        [HttpGet]
        public int Get()
        {
            throw new Exception("This is test Exception occured on Customer API Controller");
        }
    }
}
