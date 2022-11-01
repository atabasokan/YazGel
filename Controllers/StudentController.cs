using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace YazGel.Controllers
{
    public class StudentController : Controller
    {
        //[Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Info()
        {
            return View();
        }

    }
}
