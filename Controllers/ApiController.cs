using Microsoft.AspNetCore.Mvc;

namespace AjaxDemo.Controllers
{
    public class ApiController : Controller
    {
        public IActionResult Index(string name,int age=30)
        {
            if (!string.IsNullOrEmpty(name))
            {
                name = "guest";
            }
            //return Content("<h2>Ajax 你好 !!</h2>","text/html", System.Text.Encoding.UTF8)
            return Content($"Hello {name},your age is {age} years old.");
        }
    }
}
