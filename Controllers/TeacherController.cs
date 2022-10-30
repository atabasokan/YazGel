using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YazGel.Models;

namespace YazGel.Controllers
{
    [Authorize]
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
