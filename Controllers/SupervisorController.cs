using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
            var userRole = HttpContext.Session.GetInt32("userRole");
            if (userRole != 1 && userRole != 2)
            {
                return RedirectToAction("LogOut", "Login");
            }
            else
            {
                var studentData = cdb.Students.ToList();
                ViewBag.StudentData = studentData;
                var teacherData = cdb.Teachers.ToList();
                ViewBag.TeachersData = teacherData;
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
