using Employeedetails.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using static System.Net.WebRequestMethods;
using Org.BouncyCastle.Crypto;

namespace Employeedetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveConfirmationEmailController : ControllerBase
    {
        public readonly QosteqEmployeeContext _db;

        public LeaveConfirmationEmailController(QosteqEmployeeContext db)
        {
            _db = db;
        }

        [HttpPost]
        public IActionResult Post( LeaveConfirmationEmail leave)
        {
            string fromMail = "josephherman810@gmail.com";
            string fromPassword = "jldf qaoi jcqt oaur";
            string key = "123";

            //string useremail = leave.Email;
            // string useremail = "yenoklesin@gmail.com";
            string[] dates = leave.Date.Split(',');
            string formattedDate = dates[0].Trim();
            if (dates.Length > 0 && dates[0].Trim() != dates[1].Trim())
            {
                formattedDate = leave.Date;
            }
           

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = "Leave Confirmation Email";
            message.To.Add(new MailAddress(leave.Email));
            message.Body = $@"
        <html>

<body>
  
       <h3 style='font-size: 1.5rem; font-weight: bold; '>Leave Approval Form</h3>
       
        <ul style='list-style: none;'>
            <li style=""padding:2px 0px;"">Employee ID: &nbsp; {leave.EmployeeId}</li>
            <li style=""padding:2px 0px;"">Employee Name: &nbsp;{leave.EmployeeName}  </li>
            <li style=""padding:2px 0px;"">Leave Type: &nbsp; {leave.LeaveType}</li>
            <li style=""padding:2px 0px;"">Date:&nbsp; {formattedDate}</li>
            <li style=""padding:2px 0px;"">Number of Days:&nbsp; {leave.NumberOfDays}</li>
            <li style=""padding:2px 0px;"">Reason:&nbsp; {leave.Comments}</li>
          <li style='display: flex; gap: 0.75rem; margin-top: 0.35rem;'>
                click the link:  &nbsp; http://localhost:3000/confirmation/{leave.Id}
          </li>
        </ul>
      <div style=""width: 90%; display: inline-grid; height: 5vh; justify-self: end; padding-right: 10px;"">
    <img style='padding-right: 50px; width: 5%; height: 5vh;' src='https://static.wixstatic.com/media/be1b62_cc6b93d35fe4471ba5af404f465e00f8~mv2.png/v1/fill/w_184,h_110,al_c,q_85,usm_0.66_1.00_0.01,enc_auto/customcolor_logo_transparent_background.png' />
</div>
</body>
        </html>";

            message.IsBodyHtml = true;

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true
            };
            smtpClient.Send(message);

            //var dec = Decrypts(hasedpass);

            return Ok($"Email is send to the email");
        }
    }
}
