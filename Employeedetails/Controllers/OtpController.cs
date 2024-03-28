using Employeedetails.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Employeedetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OtpController : ControllerBase
    {
        private QosteqEmployeeContext _db;

        public OtpController(QosteqEmployeeContext db)
        {
            _db = db;
        }
        

        static string Encrypt(string plainText)
        {
            // Replace these values with your actual key and IV
            byte[] key = Encoding.UTF8.GetBytes("1123453454543454");
            byte[] iv = Encoding.UTF8.GetBytes("1123453454543454");

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                    }

                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }




        // GenerateRadom OTP
        private string GernerateRandomNumber()
        {
            Random random = new Random();
            int randomNumber = random.Next(100000, 999999);
            return randomNumber.ToString();
        }


        [HttpPost]
        public  IActionResult  Post(Otp otp)
        {
            var ClientuserName = otp.UserName;
            //check user
            var loginUser =  _db.Logins.FirstOrDefault(x => x.UserName == ClientuserName);
            var clientId = loginUser != null ? loginUser.Id : 0; //send to table
            // check emp id
            var EmpId = loginUser != null ? loginUser.EmployeeId : null;
            var empAPI = EmpId != null ? _db.Employeedetails.FirstOrDefault(x => x.Id == EmpId) :null;
           

            // employee emails
            var OfficeEmail = empAPI != null ? empAPI.OfficeEmail :null;
            var PersonalEmail = empAPI != null ? empAPI.PersonalEmail : null;

            // filter nullable email (To address)
            var email = OfficeEmail == null ? PersonalEmail
                        : PersonalEmail == null ? OfficeEmail
                        : OfficeEmail != null && PersonalEmail != null ? OfficeEmail : PersonalEmail; 
                        

            var OTP = email != null ? GernerateRandomNumber() : null;

            if(OTP  != null)
            {
                string fromMail = "josephherman810@gmail.com";
                string fromPassword = "jldf qaoi jcqt oaur";
                string radomNumber = OTP;
                string key = "123";
                //string hasedpass = BCrypt.Net.BCrypt.HashPassword(OTP, 10);
                string hasedpass = Encrypt(OTP);
                string useremail = email;

                //Table validate
                //await OtpTablePD(radomNumber, clientId);
                var login = _db.Logins.FirstOrDefault(x => x.Id == clientId); // filter id

                var loginData = new Login
                {
                    Id = login.Id,
                    UserName = login.UserName,
                    Password = login.Password,
                    IsDeleted = login.IsDeleted,
                    EmployeeId = login.EmployeeId,
                    Otp = hasedpass,
                    CreatedBy = login.CreatedBy,
                    CreatedDate = login.CreatedDate,
                    ModifiedBy = login.ModifiedBy,
                    ModifiedDate = login.ModifiedDate,
                };

                _db.Entry(login).CurrentValues.SetValues(loginData);
                _db.SaveChanges();

                MailMessage message = new MailMessage();
                message.From = new MailAddress(fromMail);
                message.Subject = "Inventory One Time Password";
                message.To.Add(new MailAddress(useremail));
                message.Body = $"<html><body>Your One Time Password is {radomNumber}</body></html>";
                message.IsBodyHtml = true;

                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(fromMail, fromPassword),
                    EnableSsl = true
                };
                smtpClient.Send(message);

                //var dec = Decrypts(hasedpass);

                return  Ok($"OTP is send to the email");
            }
            else
            {
                return BadRequest("UserId is wrong"); 
            }

        }
    }
}
