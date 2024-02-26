using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{
    public class StudentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create() 
        {
            return View();
        }

        public IActionResult Edit() 
        {
            return View();
        }
    }
}
