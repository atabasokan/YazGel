using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Linq;
using System.Threading.Tasks;
using YazGel.Models;
using System.IO;
using System.Collections.Generic;

namespace YazGel.Controllers
{
    public class StudentController : Controller
    {
        private IHostingEnvironment Environment;

        public StudentController(IHostingEnvironment _environment)
        {
            Environment = _environment;
        }

        Context cdb = new Context();
        Studentdb dbop = new Studentdb();
        [Authorize]
        public async Task<IActionResult> Index()
        {

            var userRole = HttpContext.Session.GetInt32("userRole");
            ViewBag.UserRole = userRole;
            if (userRole != 4)
            {
                return RedirectToAction("LogOut", "Login");
            }
            else
            {
                return View();
            }
        }

        public async Task<IActionResult> Info([Bind] ChangePass stn)
        {
            var stnId = HttpContext.Session.GetInt32("userId");
            stn.studentId = (int)stnId;

            try
            {
                if (ModelState.IsValid)
                {
                    string res = dbop.UpdatePassword(stn);
                }

            }
            catch (System.Exception)
            {

                throw;
            }
            return View();
        }

        public async Task<IActionResult> TimeLine()
        {
            return View();
        }

        public async Task<IActionResult> stajBasvuruOlusturma()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> stajBasvuruOlusturma([Bind] Internship intern)
        {
            Documents doc = new Documents();
            doc.StudentId = (int)HttpContext.Session.GetInt32("userId");
            try
            {
                if (ModelState.IsValid)
                {
                    string res = dbop.CreateInternship(intern);
                    var IId = cdb.Internships.OrderByDescending(p => p.Id).FirstOrDefault();
                    doc.InternshipId = IId.Id;
                    string res2 = dbop.CreateDocument(doc);
                }
                Student stn = new Student();
                stn.Id = doc.StudentId;
                stn.ProgressId = 1;
                string res3 = dbop.UpdateProgress(stn);
            }
            catch (Exception ex)
            {

                throw;
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> stajBasvuruOnayiYukleme()
        {
            return View();
        }

        [HttpPost]
        [RequestFormLimits(MultipartBodyLengthLimit = 104857600)]
        public async Task<IActionResult> stajBasvuruOnayiYukleme(List<IFormFile> postedFiles)
        {
            var userRole = HttpContext.Session.GetInt32("userId");
            string wwwPath = this.Environment.WebRootPath;
            string path = Path.Combine(this.Environment.WebRootPath, "pdf");
            if (!Directory.Exists(path))
            {

                Directory.CreateDirectory(path);


            }
            foreach (IFormFile postedFile in postedFiles)
            {
                string fileName = Path.GetFileName(postedFile.FileName);
                using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {

                    postedFile.CopyTo(stream);
                }
                    Student stn = new Student();
                    stn.Id = (int)userRole;
                    stn.ProgressId = 2;
                    string res3 = dbop.UpdateProgress(stn);
            }
            return View();
        }
        public async Task<IActionResult> stajDefteriYukleme()
        {
            return View();
        }

        public async Task<IActionResult> stajBasvurularim()
        {
            return View();
        }

    }
}
