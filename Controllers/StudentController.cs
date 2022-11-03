using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using YazGel.Models;

namespace YazGel.Controllers
{
    public class StudentController : Controller 
    {
        Context cdb = new Context();
        Studentdb dbop = new Studentdb();
        [Authorize]
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

        public async Task<IActionResult> Info([Bind] ChangePass stn)
        {
            var stnId = HttpContext.Session.GetInt32("userId");
            stn.studentId = (int)stnId;

            try
            {
                if (ModelState.IsValid)
                {
                    string res = dbop.UpdatePassword(stn);
                }

            }
            catch (System.Exception)
            {

                throw;
            }
            return View();
        }

        public async Task<IActionResult> TimeLine()
        {
            return View();
        }

        public async Task<IActionResult> stajBasvuruOlusturma()
        {
            return View();
        }

        public async Task<IActionResult> stajBasvurularim()
        {
            return View();
        }

    }
}
