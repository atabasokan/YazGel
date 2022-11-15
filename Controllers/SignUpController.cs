using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using YazGel.Models;
using System.Data;
using System;
using MailKit;
using System.Web;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace YazGel.Controllers
{
    public class SignUpController : Controller
    {
        Context cdb = new Context();
        Studentdb dbop = new Studentdb();

        private IConfiguration configuration;
        public SignUpController(IConfiguration IConfig)
        {
            configuration = IConfig;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string toEmail, [Bind]Student stn)
        {
            string cno = (cdb.Students.Count() + 1).ToString();
            try
            {
                if (ModelState.IsValid)
                {
                    if (cdb.Students.Any(a => a.Name == stn.Name && a.Surname == stn.Surname))
                    {
                        ViewBag.Error =  "İsmi girilen kullanıcı zaten kayıtlı.";
                        ModelState.Clear();
                        return View();
                    }
                    else
                    {

                    string no = "20220" + cno;
                    stn.No = no;
                    string Pass = GetRandomAlphanumericString();
                    stn.Pass = Pass;
                    string res = dbop.SaveRecord(stn);

                    string mailBody = "<!DOCTYPE html>" +
                                        "<html>" +
                                            "<body style=\"background -color:#ff7f26; text-align:center;\">" +
                                            "<h1 style=\"color:#051a80;\"> Kayıt Başarılı</h1>" +
                                            "<h3>Sayın öğrencimiz "+ stn.Name +" "+stn.Surname+
                                            ",</h3>"+
                                            "<h3>Staj Başvuru/Takip sistemi için profilniz oluşturuldu. Gerekli bilgiler aşağıdadır.</h3>" +
                                            "<h3>Numaranız: " + stn.No +
                                            "</h3>"+
                                            "<h3>Şifreniz: " + stn.Pass +
                                            "</h3>"+
                                            "</body>" +
                                        "</html>";
                    string mailTitle = "Staj Başvuru/Takip Sistemine Kayıt";
                    string fromEmail = "yazgelkou@gmail.com";
                    string mailSubject = "Staj Başvuru/Takip Sistemine Kayıt";
                    string mailPass = "ntrxabzataybddat";

                    //Mail Message
                    MailMessage mailMessage = new MailMessage(new MailAddress(fromEmail, mailTitle), new MailAddress(toEmail));
                    //Mail Content
                    mailMessage.Subject = mailSubject;
                    mailMessage.Body = mailBody;
                    mailMessage.IsBodyHtml = true;
                    //Server Details
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    //Credentials
                    System.Net.NetworkCredential credential = new System.Net.NetworkCredential();
                    credential.UserName = fromEmail;
                    credential.Password = mailPass;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = credential;
                    //Send Mail
                    smtp.Send(mailMessage);
                    ModelState.Clear();

                    }

                }

            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            
            return RedirectToAction("Index","Login");

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
