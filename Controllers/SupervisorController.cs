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

        [Authorize]
        public async Task<IActionResult> Index()
        {
                var studentData = cdb.Students.ToList();
                var teacherData = cdb.Teachers.ToList();
                var supervisorData = cdb.Supervisors.ToList();
            dynamic md = new ExpandoObject();
            md.allTeacher = teacherData;
            md.allSupervisor = supervisorData;
            md.allStudent = studentData;
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
                return View(md);
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
            return RedirectToAction("Index", "Supervisor");
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
            return RedirectToAction("Index", "Supervisor");
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
            return RedirectToAction("Index", "Supervisor");
        }
        //public async Task<IActionResult> EditSupervisor([Bind] Supervisor sv)
        //{
        //    var svId = HttpContext.Session.GetInt32("userId");
        //    sv.Id = (int)svId;

        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            string res = dbop.UpdatePassword(sv;
        //        }

        //    }
        //    catch (System.Exception)
        //    {

        //        throw;
        //    }
        //    return View();
        //}
        //[HttpPost]
        //public async Task<IActionResult> EditTeacher([Bind] Teacher tch)
        //{

        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            string res = dbop.EditTeacher(tch);
        //        }

        //    }
        //    catch (System.Exception)
        //    {

        //        throw;
        //    }
        //    return View();
        //}
        //public async Task<IActionResult> EditStudent([Bind] Student stn)
        //{
        //    var stnId = HttpContext.Session.GetInt32("userId");
        //    stn.Id = (int)stnId;

        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            string res = dbop.UpdatePassword(stn);
        //        }

        //    }
        //    catch (System.Exception)
        //    {

        //        throw;
        //    }
        //    return View();
        //}

        public async Task<IActionResult> TeachertoStudent()
        {
            return View();
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
