using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using YazGel.Models;

namespace YazGel.Controllers
{
    public class TeacherController : Controller
    {
        Context cdb = new Context();
        Teacherdb dbop = new Teacherdb();

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var userRole = HttpContext.Session.GetInt32("userRole");
            ViewBag.UserRole = userRole;
            if (userRole != 3)
            {
                return RedirectToAction("LogOut", "Login");
            }
            else
            {
                return View();
            }
        }

        public async Task<IActionResult> Info([Bind] ChangePass tch)
        {
            var tchId = HttpContext.Session.GetInt32("userId");
            tch.Id = (int)tchId;

            try
            {
                if (ModelState.IsValid)
                {
                    string res = dbop.UpdatePassword(tch);
                }

            }
            catch (System.Exception)
            {

                throw;
            }
            return View();
        }

        public async Task<IActionResult> Ogrenciler()
        {
            return View();
        }
    }
}
