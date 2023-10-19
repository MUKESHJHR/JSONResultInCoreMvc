using JSONResultInCoreMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Dynamic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JSONResultInCoreMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //public JsonResult Index()
        //{
        //    //Converting Key Name to Pascal case, by default it is Camel Case
        //    var options = new JsonSerializerOptions();
        //    options.PropertyNamingPolicy = null;

        //    var jsonData = new { Name = "Pranaya", ID = 4, DateOfBirth = new DateTime(1990, 06, 10) };

        //    //Returning a Collection of Objects
        //    var jsonArray = new[]
        //    {
        //        new { Name = "Pranaya", Age=25, Occupation="Designer" },
        //        new { Name = "Ramesh", Age=30, Occupation="Manager" }
        //    };

        //    List<Product> products = new List<Product>()
        //    {
        //        new Product{ Id = 1001, Name = "Laptop",  Description = "Dell Laptop" },
        //        new Product{ Id = 1002, Name = "Desktop", Description = "HP Desktop" }
        //    };

        //    //use JsonResult in ASP.NET Core MVC
        //    //return new JsonResult(jsonData);

        //    //Using JsonResult Helper Method
        //    //return Json(jsonData);

        //    //return Json(jsonArray);

        //    //Using Implicit JSON Result
        //    //return Ok(jsonArray); //// This will be automatically serialized to JSON

        //    return Json(products, options);
        //}

        public ViewResult Index()
        {
            return View();
        }

        //Calling JsonResult Action Method using jQuery AJAX
        public ActionResult Details(string Category)
        {
            //Converting Key Name to Pascal case, by default it is Camel Case
            var options = new JsonSerializerOptions();
            options.PropertyNamingPolicy = null;
            
            try
            {
                //Based on the Category Fetch the Data from the database 
                //Here, we have hard coded the data
                List<Product> products = new List<Product>
                {
                    new Product{ Id = 1001, Name = "Laptop",  Description = "Dell Laptop" },
                    new Product{ Id = 1002, Name = "Desktop", Description = "HP Desktop" },
                    new Product{ Id = 1003, Name = "Mobile", Description = "Apple IPhone" }
                };
                //Please uncomment the following two lines if you want see what happend when exception occurred
                int a = 10, b = 0;
                int c = a / b;
                return Json(products, options);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { Message = ex.Message, StackTrace = ex.StackTrace, ExceptionType = "Internal Server Error" }, options)
                {
                    StatusCode = StatusCodes.Status500InternalServerError // Status code here 
                };
            }

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}