using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using YazGel.Models;

namespace YazGel.Controllers
{
    public class CommitteeController : Controller
    {
        Context cdb = new Context();
        Teacherdb dbop = new Teacherdb();
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

        public async Task<IActionResult> Info([Bind]ChangePass tch)
        {
            var Id = HttpContext.Session.GetInt32("userId");
            tch.Id = (int)Id;

            try
            {
                if (ModelState.IsValid)
                {
                    string res = dbop.UpdatePasswordCom(tch);
                }

            }
            catch (System.Exception)
            {

                throw;
            }
            return View();
        }

        public async Task<IActionResult> FirmaOnaylıBelgeyeSahipOgrencilerListe()
        {

            return View();
        }

        public async Task<IActionResult> OgrenciyeOgretmenAtama()
        {

            return View();
        }
    }
}
