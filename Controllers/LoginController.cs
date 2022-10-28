using Microsoft.AspNetCore.Mvc;

namespace YazGel.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
