using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using YazGel.Models;

namespace YazGel.Controllers
{
    public class TeacherController : Controller
    {
        private IHostingEnvironment Environment;

        public TeacherController(IHostingEnvironment _environment)
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
            var userRole = HttpContext.Session.GetInt32("userRole");
            ViewBag.UserRole = userRole;
            if (userRole != 3)
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
            var tchId = HttpContext.Session.GetInt32("userId");
            tch.Id = (int)tchId;

            try
            {
                if (ModelState.IsValid)
                {
                    string res = dbop.UpdatePassword(tch);
                }

            }
            catch (System.Exception)
            {

                throw;
            }
            return View();
        }

        public async Task<IActionResult> Ogrenciler()
        {
            var tchId = HttpContext.Session.GetInt32("userId");
            var studentsListData = cdb.Students.Where(w => w.TeacherId == tchId && w.ProgressId == 5).ToList();
            ViewBag.studentsListData = studentsListData;

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
        public FileResult DownloadFile(int stnId, string filename)
        {
            var sId = HttpContext.Session.GetInt32("StnId");
            stnId = (int)sId;
            string path = Path.Combine(this.Environment.WebRootPath, "pdf/" + stnId + "/") + filename;
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            return File(bytes, "application/octet-stream", filename);
        }

        public async Task<IActionResult> Confirm(bool conf, int stnId)
        {
            Student stn = new Student();
            stn.Id = stnId;
            if (conf == true)
            {
                stn.ProgressId = 6;
                string res = dbop2.UpdateProgress(stn);
                string res2 = dbop3.ClearStudent(stnId);
                return RedirectToAction("Ogrenciler", "Teacher");
            }
            else
            {
                stn.ProgressId = 4;
                string res = dbop2.UpdateProgress(stn);
                string res2 = dbop3.ClearStudent(stnId);

                return RedirectToAction("Ogrenciler", "Teacher");
            }
        }
    }
}
