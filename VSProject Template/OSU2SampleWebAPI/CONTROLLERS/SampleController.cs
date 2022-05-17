using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace $safeprojectname$.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<$safeprojectname$.Models.SampleModel> Get()
        {
            //return new List<$safeprojectname$.Models.SampleModel>
            //{
            //    new $safeprojectname$.Models.SampleModel { Name=  "Sample1", Description = "", Version = "1.0" },
            //    new $safeprojectname$.Models.SampleModel { Name=  "Sample1", Description = "", Version = "1.0.1" }
            //}

            return Enumerable.Range(1, 2).Select(index => 
                new $safeprojectname$.Models.SampleModel { Name = "Sample " + index, Description = "", Version = "1.0" }).
            ToArray();

            
        }
    }
}
