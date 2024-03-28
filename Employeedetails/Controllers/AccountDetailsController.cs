using Employeedetails.DTO.AccountDetails;
using Employeedetails.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employeedetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountDetailsController : ControllerBase
    {
        private readonly QosteqEmployeeContext _db;
        public AccountDetailsController(QosteqEmployeeContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = from account in _db.Accountdetails
                         join employee in _db.Employeedetails on account.EmployeeId equals employee.Id
                         select new
                         {
                             AccountId = account.Id,
                             EmployeeId = account.EmployeeId,
                             BankName = account.BankName,
                             BranchName = account.BranchName,
                             BankLocation = account.BankLocation,
                             AccountNumber = account.AccountNumber,
                             Ifsc = account.Ifsc,
                             CreatedDate = account.CreatedDate,
                             CreatedBy = account.CreatedBy,
                             ModifiedDate = account.ModifiedDate,
                             ModifiedBy = account.ModifiedBy,
                             IsDeleted = account.Isdeleted,
                             EmployeeFirstName = employee.FirstName,
                             EmployeeLastName = employee.LastName,
                             // Add other properties as needed
                         };

            return Ok(result.ToList());
        }

    //[HttpGet]
    //public IActionResult Get()
    //{
    //   List<Accountdetail> accountdetails = new List<Accountdetail>();
    //    accountdetails = _db.Accountdetails.ToList();
    //    return Ok(accountdetails);
    //}
    
  
    [HttpPost]
        public IActionResult Post(PostAccountDetailsDTO accontDetails)
        {
            Accountdetail accountdetail = new Accountdetail
            {
              //Id = accontDetails.Id,
              EmployeeId = accontDetails.EmployeeId,
              BankName = accontDetails.BankName,
                BranchName = accontDetails.BranchName,
                BankLocation = accontDetails.BankLocation,
                AccountNumber = accontDetails.AccountNumber,
                Ifsc = accontDetails.Ifsc,
                Isdeleted = accontDetails.Isdeleted,
                //CreatedBy = accontDetails.CreatedBy,
                //CreatedDate = accontDetails.CreatedDate,
                //ModifiedDate = accontDetails.ModifiedDate,
                //ModifiedBy = accontDetails.ModifiedBy
            };
            _db.Add(accountdetail);
            _db.SaveChanges();
            return Ok(accontDetails);
        }

        [HttpPut("{id:long}")]
        public IActionResult Put(long id, PutAccountDetailDTO accountDetailDTO)
        {
            var account = _db.Accountdetails.Find(id);

            account.Id = accountDetailDTO.Id;
            account.EmployeeId = accountDetailDTO.EmployeeId;
            account.BankName = accountDetailDTO.BankName;
            account.BranchName = accountDetailDTO.BranchName;
            account.BankLocation = accountDetailDTO.BankLocation;
            account.AccountNumber = accountDetailDTO.AccountNumber;
            account.Ifsc = accountDetailDTO.Ifsc;
            account.Isdeleted = accountDetailDTO.Isdeleted;
            account.CreatedBy = accountDetailDTO.CreatedBy;
            account.CreatedDate = accountDetailDTO.CreatedDate;
            account.ModifiedBy = accountDetailDTO.ModifiedBy;
            account.ModifiedDate = accountDetailDTO.ModifiedDate;
            _db.Accountdetails.Update(account);
            _db.SaveChanges();
            return Ok(account);
        }

        [HttpDelete("{id:long}")]
        public IActionResult Delete(long id) 
        { 
            var account = _db.Accountdetails.FirstOrDefault(x => x.Id == id);
            if (account == null)
            {
                return NotFound($"Account with ID {id} not found.");
            }
            _db.Accountdetails.Remove(account);
            _db.SaveChanges();
            return Ok();
        }
    }
}
 