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
            //var status1 = false;
            //var status2 = false;
            //var status3 = false;

            //for (int i = 0; i < 1; i++)
            //{
            //    Console.WriteLine("i = " + i);

            //    var method1 = true;
            //    status1 = method1;


            //    if (status1 == true)
            //    {

            //        var method2 = true;
            //        status2 = method2;

            //    }
            //    else 
            //    {
            //        Console.WriteLine("method1 fail");

            //    }




            //    if (status1 && status2 == true)
            //    {
            //        var method3 = false;
            //        status3 = method3;
            //    }
            //    else if(status1 == true && status2 == false)
            //    {
            //        Console.WriteLine("method2 fail");
            //    }




            //    if (status1 && status2 && status3 == true)
            //    {
            //        var method4 = false;

            //    }
            //    else if (status1 == true && status2 == true && status3 == false)
            //    {
            //        Console.WriteLine("method3 fail");
            //    }


            //}



            _renew.RunTask();
            Console.WriteLine("response OK");
            return Ok("response OK");
        }
    }
}
