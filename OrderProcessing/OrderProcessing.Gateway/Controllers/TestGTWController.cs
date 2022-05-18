using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Helper;

namespace OrderProcessing.Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestGTWController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            throw new AppException("Test Exception");
            throw new Exception("Test Exception 2 with Middleware");

            return "Hello World";
        }
    }
}
