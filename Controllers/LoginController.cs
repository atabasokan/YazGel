using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using YazGel.Models;

namespace YazGel.Controllers
{
    public class LoginController : Controller
    {
        Context cdb = new Context();

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            HttpContext.Session.Clear();
            return View();
        }

        public async Task<IActionResult> Index(Student s, Teacher t, Supervisor sv)
        {
            var infos = cdb.Students.FirstOrDefault(x => x.No == s.No && x.Pass == s.Pass);
            if (infos != null)
            {
                HttpContext.Session.SetInt32("userRole", infos.role);
                HttpContext.Session.SetInt32("userId", infos.Id);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, infos.Name + " " + infos.Surname )
                };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Student");
            }
            var infot = cdb.Teachers.FirstOrDefault(x => x.No == t.No && x.Pass == t.Pass);
            if (infot != null)
            {
                HttpContext.Session.SetInt32("userRole", infot.role);
                HttpContext.Session.SetInt32("userId", infot.Id);
                string type = (infot.Type).ToString();
                HttpContext.Session.SetString("teacherType", type);
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, infot.Name));
                claims.Add(new Claim(ClaimTypes.Surname, infot.Surname));
                claims.Add(new Claim(ClaimTypes.UserData, infot.Pass));
                claims.Add(new Claim(ClaimTypes.GivenName, infot.No));
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                if (infot.Type == true)
                {
                    return RedirectToAction("Index", "Committee");
                }
                else
                {
                    return RedirectToAction("Index", "Teacher");
                }
            }
            var infosv = cdb.Supervisors.FirstOrDefault(x => x.No == sv.No && x.Pass == sv.Pass);
            if (infosv != null)
            {
                HttpContext.Session.SetInt32("userRole", infosv.role);
                HttpContext.Session.SetInt32("userId", infosv.Id);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, infosv.Name + " " + infosv.Surname )
                };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Supervisor");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");

        }
    }
}
