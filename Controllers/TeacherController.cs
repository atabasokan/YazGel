using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using YazGel.Models;

namespace YazGel.Controllers
{
    public class TeacherController : Controller
    {
    [Authorize]
        public async Task<IActionResult> Index()
        {
            var userRole = HttpContext.Session.GetInt32("userRole");
            if (userRole != 3)
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
