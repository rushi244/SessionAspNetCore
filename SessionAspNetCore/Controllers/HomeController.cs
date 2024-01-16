using Microsoft.AspNetCore.Mvc;
using SessionAspNetCore.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace SessionAspNetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            HttpContext.Session.SetString("MySession","Rushikesh");
            return View();
        }
        public IActionResult About()
        {

            if (HttpContext.Session.GetString("MySession") != null)
            {
                ViewBag.Data = HttpContext.Session.GetString("MySession").ToString();
            }
            return View();
        }
        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("MySession") != null)
            {
                HttpContext.Session.Remove("MySession");
            }
            return View();
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