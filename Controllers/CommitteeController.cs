using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace YazGel.Controllers
{
    public class CommitteeController : Controller
    {
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var type = HttpContext.Session.GetString("teacherType");
            if (type != "True")
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
