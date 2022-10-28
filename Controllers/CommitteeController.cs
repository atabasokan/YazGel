using Microsoft.AspNetCore.Mvc;

namespace YazGel.Controllers
{
    public class CommitteeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
