using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace YazGel.Controllers
{
    public class StudentController : Controller 
    {
        //[Authorize]
        public async Task<IActionResult> Index()
        {
            
            var userRole = HttpContext.Session.GetInt32("userRole");
            ViewBag.UserRole = userRole;
            if(userRole != 4)
            {
                return RedirectToAction("LogOut","Login");
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

    }
}
