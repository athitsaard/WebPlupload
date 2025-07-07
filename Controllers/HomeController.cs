using System.Diagnostics;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using WebPlupload.Models;
using WebPlupload.Sevices;

namespace WebPlupload.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly Renew _renew;


        private readonly string _uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

        public HomeController(ILogger<HomeController> logger)
        {
            
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        //public IActionResult AutoRenew()
        //{
            
            
            
        //    _renew.RunTask();
        //    Console.WriteLine("response OK");
        //    return Ok("response OK");
        //}
        public IActionResult Privacy()
        {
            return View();
        }


        [HttpPost]
        public  void upload()
        {


            var chunk = Request.Form.Files[0];
            var fileName = Request.Form["name"];
            var chunkIndex = int.Parse(Request.Form["chunk"]);
            var totalChunks = int.Parse(Request.Form["chunks"]);


            var tempPath = Path.Combine(_uploadPath, fileName + ".part" + chunkIndex);
            // Directory.CreateDirectory(_uploadPath);
            using (var stream = new FileStream(tempPath, chunkIndex == 0 ? FileMode.Create : FileMode.Append))
            {
                 chunk.CopyTo(stream);           
            }



            // ตรวจสอบว่าทุก chunk ถูกอัปโหลดครบหรือยัง
            var uploadedChunks = Directory.GetFiles(_uploadPath, fileName + ".part*");
            if (uploadedChunks.Length == totalChunks)
            {
                var finalPath = Path.Combine(_uploadPath, fileName);
                using (var finalStream = new FileStream(finalPath, FileMode.Create))
                {
                    for (int i = 0; i < totalChunks; i++)
                    {
                        var partPath = Path.Combine(_uploadPath, fileName + ".part" + i);
                        using (var partStream = new FileStream(partPath, FileMode.Open))
                        {
                             partStream.CopyTo(finalStream);
                        }
                        System.IO.File.Delete(partPath); // ลบ chunk หลังรวม
                    }
                }
            }





        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
