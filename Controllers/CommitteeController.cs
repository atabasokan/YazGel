using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using YazGel.Models;

namespace YazGel.Controllers
{
    public class CommitteeController : Controller
    {
        Context cdb = new Context();
        Teacherdb dbop = new Teacherdb();
        Studentdb dbop2 = new Studentdb();
        Supervisordb dbop3 = new Supervisordb();

        [Authorize]
        public async Task<IActionResult> Index()
        {

            var studentData = cdb.Students.Where(w => w.ProgressId == 2).ToList();
            ViewBag.StudentProgressData = studentData;
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
        public async Task<IActionResult> FirmaOnaylıBelgeyeSahipOgrencilerListe(int stnId)
        {
            if(stnId != 0)
            {
                Student stn = new Student();
                stn.Id = stnId;
                stn.ProgressId = 3;
                string res3 = dbop2.UpdateProgress(stn);
                return RedirectToAction("FirmaOnaylıBelgeyeSahipOgrencilerListe", "Committee");
            }
            else
            {
            var studentData = cdb.Students.Where(w => w.ProgressId == 2).ToList();
            ViewBag.StudentProgressData = studentData;
            return View();
            }
        }

        public async Task<IActionResult> OgrenciyeOgretmenAtama(int stnId, int tId)
        {
            if (stnId != 0)
            {
                HttpContext.Session.SetInt32("StnId", stnId);
            }
            var teacherData = cdb.Teachers.ToList();
            ViewBag.TeachersData = teacherData;
            if (tId != 0)
            {
                var sId = HttpContext.Session.GetInt32("StnId");
                stnId = (int)sId;
                string res = dbop3.TeachertoStudent(stnId, tId);
                Student stn = new Student();
                stn.Id = stnId;
                stn.ProgressId = 5;
                string res2 = dbop2.UpdateProgress(stn);
                return RedirectToAction("OgrenciyeOgretmenAtama", "Committee");
            }
            return View();
        }
    }
}
