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
    [Authorize]
        Context cdb = new Context();
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
