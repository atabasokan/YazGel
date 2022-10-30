using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace YazGel.Controllers
{
    public class SupervisorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
