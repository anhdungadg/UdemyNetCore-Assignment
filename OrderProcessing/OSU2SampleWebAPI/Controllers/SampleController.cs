using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OSU2SampleWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<OSU2SampleWebAPI.Models.SampleModel> Get()
        {
            return Enumerable.Range(1, 2).Select(index => 
                new OSU2SampleWebAPI.Models.SampleModel { Name = "Sample " + index, Description = "", Version = "1.0" }).
            ToArray();

            
        }
    }
}
