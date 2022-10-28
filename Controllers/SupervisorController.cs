using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace YazGel.Controllers
{
    public class SupervisorController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
