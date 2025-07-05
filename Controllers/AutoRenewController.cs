using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebPlupload.Sevices;

namespace WebPlupload.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class AutoRenewController : ControllerBase
    {
        private readonly Renew _renew;

        public AutoRenewController(Renew renew)
        {
            _renew = renew;
        }

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {






            _renew.RunTask();
            Console.WriteLine("response OK");
            return Ok("response OK");
        }
    }
}
