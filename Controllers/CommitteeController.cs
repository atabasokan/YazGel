using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web.Providers.Entities;
using YazGel.Models;

namespace YazGel.Controllers
{
    public class CommitteeController : Controller
    {
        private IHostingEnvironment Environment;

        public CommitteeController(IHostingEnvironment _environment)
        {
            Environment = _environment;
        }
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

        public async Task<IActionResult> Info([Bind] ChangePass tch)
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
            if (stnId != 0)
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
        public async Task<IActionResult> StajDefteriYukleyenOgrencilerListe(int stnId)
        {
            if (stnId != 0)
            {
                Student stn = new Student();
                stn.Id = stnId;
                stn.ProgressId = 5;
                string res3 = dbop2.UpdateProgress(stn);
                return RedirectToAction("StajDefteriYukleyenOgrencilerListe", "Committee");
            }
            else
            {
                var studentData = cdb.Students.Where(w => w.ProgressId == 4 || w.ProgressId == 5).ToList();
                ViewBag.StudentProgressData2 = studentData;
                return View();
            }
        }

        public async Task<IActionResult> OgrenciyeOgretmenAtama(int stnId, int tId)
        {
            if (stnId != 0)
            {
                HttpContext.Session.SetInt32("StnId", stnId);
            }
            var teacherData = cdb.Teachers.Where(w => w.Type == false).ToList();
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
                return RedirectToAction("StajDefteriYukleyenOgrencilerListe", "Committee");
            }
            return View();
        }
        public async Task<IActionResult> Documents(int stnId)
        {
            HttpContext.Session.SetInt32("StnId", stnId);
            string[] filepaths = Directory.GetFiles(Path.Combine(this.Environment.WebRootPath, "pdf/" + stnId));
            List<Models.File> list = new List<Models.File>();
            foreach (string file in filepaths)
            {
                list.Add(new Models.File { Name = Path.GetFileName(file) });
            }
            return View(list);

        }
        [HttpGet]
        public async Task<IActionResult> ClearStudent(int stnId)
        {
            HttpContext.Session.SetInt32("StnId", stnId);
            var sId = HttpContext.Session.GetInt32("StnId");
            stnId = (int)sId;
            string res = dbop3.ClearStudent(stnId);
            Student stn = new Student();
            stn.Id = stnId;
            stn.ProgressId = 4;
            string res2 = dbop2.UpdateProgress(stn);
            return RedirectToAction("StajDefteriYukleyenOgrencilerListe", "Committee");
        }
        public FileResult DownloadFile(int stnId, string filename)
        {
            var sId = HttpContext.Session.GetInt32("StnId");
            stnId = (int)sId;
            string path = Path.Combine(this.Environment.WebRootPath, "pdf/" + stnId + "/") + filename;
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            return File(bytes, "application/octet-stream",filename);
        }
    }
}
