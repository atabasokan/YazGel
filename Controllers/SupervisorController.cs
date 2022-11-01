using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace YazGel.Controllers
{
    public class SupervisorController : Controller
    {
    [Authorize]
        public IActionResult Index()
        {
            var userRole = HttpContext.Session.GetInt32("userRole");
            if (userRole != 1)
            {
                return RedirectToAction("LogOut", "Login");
            }
            else
            {
                return View();
            }
        }
    }
}
