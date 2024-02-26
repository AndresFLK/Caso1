using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class ProfessorsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id) { 
             return View();
        }
    }
}
