using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace YazGel.Controllers
{
    [Authorize]
    public class SupervisorController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var userRole = HttpContext.Session.GetInt32("userRole");
            if (userRole != 1 && userRole != 2)
            {
                return RedirectToAction("LogOut", "Login");
            }
            else
            {
                return View();
            }
        }

        public async Task<IActionResult> Info()
        {
            return View();
        }

        public async Task<IActionResult> AddTeacher()
        {
            return View();
        }

        public async Task<IActionResult> TeachertoStudent()
        {
            return View();
        }
    }
}
