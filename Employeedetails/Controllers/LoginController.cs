using Employeedetails.DTO.Login;
using Employeedetails.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employeedetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public readonly QosteqEmployeeContext _db;

        public LoginController(QosteqEmployeeContext db)
        {
            _db = db;
        }

        //private bool VerifyPassword(string hashedPassword, string enteredPassword)
        //{
        //    return BCrypt.Net.BCrypt.Verify(enteredPassword, hashedPassword);
        //}

        [HttpGet]
        public IActionResult Get()
        {
            List<Login> Login = new List<Login>();
            Login = _db.Logins.ToList();
            return Ok(Login);
        }

        [HttpPost]
        public IActionResult Post(PostLoginDTO post)
        {
            var Login = new Login
            {
                EmployeeId = post.EmployeeId,
                UserName = post.UserName,
                Password = post.Password,
                IsDeleted = post.IsDeleted,
                Otp=post.Otp,
                CreatedBy = post.CreatedBy,
                CreatedDate = post.CreatedDate,
                ModifiedBy = post.ModifiedBy,
                ModifiedDate = post.ModifiedDate,
            };
            _db.Logins.Add(Login);
            _db.SaveChanges();
            return Ok(Login);
        }

        //[HttpPost("login")]
        //public IActionResult Login (CheckLoginDTO login)
        //{
        //    var user = _db.Logins.FirstOrDefault(x => x.UserName == login.UserName);
            
        //    if(user ==null)
        //    {
        //        return Unauthorized();
        //    };

        //    if(VerifyPassword(user.Password,login.Password))
        //    {
        //    return Ok("Login successful");
        //    }
        //    else
        //    {
        //        // Passwords do not match
        //        return Unauthorized();
        //    };
        //}

        [HttpPut("{id:long}")]
        public IActionResult Put(PutLoginDTO put)
        {
            var Login = new Login
            {
                Id = put.Id,
                EmployeeId = put.EmployeeId,
                UserName = put.UserName,
                Password = put.Password,
                Otp = put.Otp,
                IsDeleted = put.IsDeleted,
                CreatedBy = put.CreatedBy,
                CreatedDate = put.CreatedDate,
                ModifiedBy = put.ModifiedBy,
                ModifiedDate = put.ModifiedDate,
            };
            _db.Logins.Update(Login);
            _db.SaveChanges();
            return Ok(Login);
        }

        [HttpDelete("{id:long}")]
        public IActionResult Delete(int id)
        {
            var Login = _db.Logins.FirstOrDefault(x => x.Id == id);
            _db.Logins.Remove(Login);
            _db.SaveChanges();
            return Ok();
        }

    }
}
