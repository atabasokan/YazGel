using Microsoft.AspNetCore.Mvc;

namespace YazGel.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
