using Microsoft.AspNetCore.Mvc;

namespace YazGel.Controllers
{
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
