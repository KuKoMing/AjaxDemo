using AjaxDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AjaxDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DemoContext _demoContext;
        public HomeController(ILogger<HomeController> logger,DemoContext context)
        {
            _demoContext = context;
            _logger = logger;
        }
        public IActionResult Test()
        {
            var mem = _demoContext.Members.Where(p => p.MemberId == 1);
            return View(mem);
        }



        public IActionResult Index()
        {
            return View();
        }

        public IActionResult First()
        {
            return View();

        }
        public IActionResult Register()
        {
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