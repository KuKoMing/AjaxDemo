using AjaxDemo.Models;
using AjaxDemo.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace AjaxDemo.Controllers
{
    public class ApiController : Controller
    {
        private readonly IWebHostEnvironment _host;
        private readonly DemoContext _context;

        public ApiController(IWebHostEnvironment host,DemoContext Context)
        {
            _host = host;
            _context = Context;
        }




        public IActionResult Index(string name, int age = 30)
        {
            System.Threading.Thread.Sleep(5000);
            if (!string.IsNullOrEmpty(name))
            {
                name = "guest";
            }
            //return Content("<h2>Ajax 你好 !!</h2>","text/html", System.Text.Encoding.UTF8)
            return Content($"Hello {name},your age is {age} years old.");
            
        }

        public IActionResult register(MemberViewModel member ,IFormFile formFile)
        {
            string strpath = Path.Combine(_host.WebRootPath, "uploads" +
                "", formFile.FileName);

            using (var filestream = new FileStream(strpath, FileMode.Create))
            { 
            formFile.CopyTo(filestream);
            }
            return Content(strpath);

            //return Content($"Hello{member.name},{member.email},you are {member.age} years old.");

        }

        public IActionResult checkAccount( string name)
        { 
            //var mem =  _context.Members.Where(p => p.Name.Contains(member.name));
            if ( !_context.Members.Any(p=>p.Name==name) )
            {
                return Content("此名稱無人使用");
            }
            else
            {
                return Content("此名稱已被使用");
            }            
        }
    }
}
