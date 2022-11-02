using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using YazGel.Models;

namespace YazGel.Controllers
{
    public class SupervisorController : Controller
    {
        Context cdb = new Context();
        Supervisordb dbop = new Supervisordb();

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var userRole = HttpContext.Session.GetInt32("userRole");
            if (userRole != 1 && userRole != 2)
            {
                return RedirectToAction("LogOut", "Login");
            }
            else
            {
                var studentData = cdb.Students.ToList();
                ViewBag.StudentData = studentData;
                var teacherData = cdb.Teachers.ToList();
                ViewBag.TeachersData = teacherData;
                return View();
            }
        }

        public async Task<IActionResult> Info([Bind] ChangePass sv)
        {
            var svId = HttpContext.Session.GetInt32("userId");
            sv.Id = (int)svId;

            try
            {
                if (ModelState.IsValid)
                {
                    string res = dbop.UpdatePassword(sv);
                }

            }
            catch (System.Exception)
            {

                throw;
            }
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
