using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Index(Student s,Teacher t,Supervisor sv)
        {
            var infos = cdb.Students.FirstOrDefault(x => x.No == s.No && x.Pass == s.Pass);
            if (infos != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, s.No)
                };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Student");
            }
            var infot = cdb.Teachers.FirstOrDefault(x => x.No == t.No && x.Pass == t.Pass );
            if (infot != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, infot.Name + " " + infot.Surname )
                };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                if(infot.Type == true)
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
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, sv.No)
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
