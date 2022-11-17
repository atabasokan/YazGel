using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Xamarin.Essentials;
using YazGel.Models;

namespace YazGel.Controllers
{
    public class SupervisorController : Controller
    {
        Context cdb = new Context();
        Supervisordb dbop = new Supervisordb();
        Studentdb dbop2 = new Studentdb();

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var studentData = cdb.Students.ToList();
            var teacherData = cdb.Teachers.ToList();
            var supervisorData = cdb.Supervisors.ToList();
            var userRole = HttpContext.Session.GetInt32("userRole");
            ViewBag.UserRole = userRole;
            if (userRole != 1 && userRole != 2)
            {
                return RedirectToAction("LogOut", "Login");
            }
            else
            {
                ViewBag.StudentData = studentData;
                ViewBag.TeachersData = teacherData;
                ViewBag.SupervisorsData = supervisorData;
                return View();
            }
        }

        public async Task<IActionResult> Info([Bind] ChangePass sv)
        {
            var svId = HttpContext.Session.GetInt32("userId");
            sv.Id = (int)svId;

            try
            {
                if (ModelState.IsValid)
                {
                    string res = dbop.UpdatePasswordSv(sv);
                }

            }
            catch (System.Exception)
            {

                throw;
            }
            return View();
        }

        public async Task<IActionResult> Teachers()
        {
            var studentData = cdb.Students.ToList();
            var teacherData = cdb.Teachers.ToList();
            var supervisorData = cdb.Supervisors.Where(w => w.role == 2).ToList();
            var userRole = HttpContext.Session.GetInt32("userRole");
            ViewBag.UserRole = userRole;
            if (userRole != 1 && userRole != 2)
            {
                return RedirectToAction("LogOut", "Login");
            }
            else
            {
                ViewBag.SupervisorsData = supervisorData;
                ViewBag.TeachersData = teacherData;
                ViewBag.StudentsData = studentData;
                return View();
            }

        }
        public async Task<IActionResult> Students()
        {
            var studentData = cdb.Students.ToList();
            var teacherData = cdb.Teachers.ToList();
            var supervisorData = cdb.Supervisors.Where(w => w.role == 2).ToList();
            var userRole = HttpContext.Session.GetInt32("userRole");
            ViewBag.UserRole = userRole;
            if (userRole != 1 && userRole != 2)
            {
                return RedirectToAction("LogOut", "Login");
            }
            else
            {
                ViewBag.SupervisorsData = supervisorData;
                ViewBag.TeachersData = teacherData;
                ViewBag.StudentsData = studentData;
                return View();
            }

        }
        public async Task<IActionResult> Supervisors()
        {
            var studentData = cdb.Students.ToList();
            var teacherData = cdb.Teachers.ToList();
            var supervisorData = cdb.Supervisors.Where(w => w.role == 2).ToList();
            var userRole = HttpContext.Session.GetInt32("userRole");
            ViewBag.UserRole = userRole;
            if (userRole != 1 && userRole != 2)
            {
                return RedirectToAction("LogOut", "Login");
            }
            else
            {
                ViewBag.SupervisorsData = supervisorData;
                ViewBag.TeachersData = teacherData;
                ViewBag.StudentsData = studentData;
                return View();
            }

        }
        public async Task<IActionResult> AddTeacher()
        {

            return View();

        }
        public async Task<IActionResult> AddSupervisor()
        {

            return View();

        }
        [HttpPost]
        public async Task<IActionResult> AddTeacher([Bind] Teacher tch)
        {
            tch.role = 3;
            string cno = (cdb.Teachers.Count() + 1).ToString();
            try
            {
                if (ModelState.IsValid)
                {

                    string no = "20221" + cno;
                    tch.No = no;
                    string Pass = GetRandomAlphanumericString();
                    tch.Pass = Pass;
                    string res = dbop.SaveRecord(tch);

                }

            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return RedirectToAction("AddTeacher", "Supervisor");
        }
        [HttpPost]
        public async Task<IActionResult> AddSupervisor([Bind] Supervisor sv)
        {
            sv.role = 2;
            string cno = (cdb.Supervisors.Count() + 1).ToString();
            try
            {
                if (ModelState.IsValid)
                {

                    string no = "20222" + cno;
                    sv.No = no;
                    string Pass = GetRandomAlphanumericString();
                    sv.Pass = Pass;
                    string res = dbop.SaveSupervisor(sv);

                }

            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return RedirectToAction("AddSupervisor", "Supervisor");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteSupervisor([Bind] Supervisor sv)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    string res = dbop.DeleteSupervisor(sv);

                }

            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return RedirectToAction("Supervisors", "Supervisor");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteTeacher([Bind] Teacher tch)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    string res = dbop.DeleteTeacher(tch);

                }

            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return RedirectToAction("Teachers", "Supervisor");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteStudent([Bind] Student st)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    string res = dbop.DeleteStudent(st);

                }

            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return RedirectToAction("Students", "Supervisor");
        }
        public async Task<IActionResult> EditSupervisor(int svId)
        {
            HttpContext.Session.SetInt32("svId", svId);
            return View();
        }
        public async Task<IActionResult> EditTeacher(int tchId)
        {
            HttpContext.Session.SetInt32("tchId", tchId);
            return View();
        }
        public async Task<IActionResult> EditStudent(int stnId)
        {
            HttpContext.Session.SetInt32("stnId", stnId);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditSupervisor([Bind] Supervisor sv)
        {
            var svId = HttpContext.Session.GetInt32("svId");
            sv.Id = (int)svId;
            try
            {
                if (ModelState.IsValid)
                {
                    string res = dbop.EditSupervisor(sv);
                }

            }
            catch (System.Exception)
            {

                throw;
            }
            return RedirectToAction("Supervisors", "Supervisor");
        }
        [HttpPost]
        public async Task<IActionResult> EditTeacher([Bind] Teacher tch)
        {
            var tchId = HttpContext.Session.GetInt32("tchId");
            tch.Id = (int)tchId;
            try
            {
                if (ModelState.IsValid)
                {
                    string res = dbop.EditTeacher(tch);
                }

            }
            catch (System.Exception)
            {

                throw;
            }
            return RedirectToAction("Teachers", "Supervisor");
        }
        [HttpPost]
        public async Task<IActionResult> EditStudent([Bind] Student stn)
        {
            var stnId = HttpContext.Session.GetInt32("stnId");
            stn.Id = (int)stnId;
            try
            {
                if (ModelState.IsValid)
                {
                    string res = dbop.EditStudent(stn);
                }

            }
            catch (System.Exception)
            {

                throw;
            }
            return RedirectToAction("Students", "Supervisor");
        }
        public async Task<IActionResult> TeachertoStudent(int stnId, int tId)
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
                string res = dbop.TeachertoStudent(stnId, tId);
                Student stn = new Student();
                stn.Id = stnId;
                stn.ProgressId = 5;
                string res2 = dbop2.UpdateProgress(stn);
            return RedirectToAction("Students", "Supervisor");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ClearStudent(int stnId)
        {
            HttpContext.Session.SetInt32("StnId", stnId);
            var sId = HttpContext.Session.GetInt32("StnId");
            stnId = (int)sId;
            string res = dbop.ClearStudent(stnId);
            return RedirectToAction("Students", "Supervisor");
        }
        public static string GetRandomAlphanumericString()
        {
            Random random = new Random();
            const string alphanumericCharacters =
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
                "abcdefghijklmnopqrstuvwxyz" +
                "0123456789";
            return new string(alphanumericCharacters.Select(c => alphanumericCharacters[random.Next(alphanumericCharacters.Length)]).Take(8).ToArray());
        }
        public static string GetRandomString(int length, IEnumerable<char> characterSet)
        {
            if (length < 0)
                throw new ArgumentException("length must not be negative", "length");
            if (length > int.MaxValue / 8) // 250 million chars ought to be enough for anybody
                throw new ArgumentException("length is too big", "length");
            if (characterSet == null)
                throw new ArgumentNullException("characterSet");
            var characterArray = characterSet.Distinct().ToArray();
            if (characterArray.Length == 0)
                throw new ArgumentException("characterSet must not be empty", "characterSet");

            var bytes = new byte[length * 8];
            new RNGCryptoServiceProvider().GetBytes(bytes);
            var result = new char[length];
            for (int i = 0; i < length; i++)
            {
                ulong value = BitConverter.ToUInt64(bytes, i * 8);
                result[i] = characterArray[value % (uint)characterArray.Length];
            }
            return new string(result);
        }

    }
}
