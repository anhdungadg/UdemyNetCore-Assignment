using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OSU2SampleWebAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<OSU2SampleWebAPI1.Models.SampleModel> Get()
        {
            //return new List<OSU2SampleWebAPI1.Models.SampleModel>
            //{
            //    new OSU2SampleWebAPI1.Models.SampleModel { Name=  "Sample1", Description = "", Version = "1.0" },
            //    new OSU2SampleWebAPI1.Models.SampleModel { Name=  "Sample1", Description = "", Version = "1.0.1" }
            //}

            return Enumerable.Range(1, 2).Select(index =>
                new OSU2SampleWebAPI1.Models.SampleModel { Name = "Sample " + index, Description = "", Version = "1.0" }).
            ToArray();


        }
    }
}
