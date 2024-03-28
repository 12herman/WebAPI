using Employeedetails.DTO.LeaveHistory;
using Employeedetails.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employeedetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveHistoryController : ControllerBase
    {
        public readonly QosteqEmployeeContext _db;
        public LeaveHistoryController(QosteqEmployeeContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<Leavehistory> leavehistories = new List<Leavehistory>();
            leavehistories = _db.Leavehistories.ToList();
            return Ok(leavehistories);
        }

        [HttpPost]
        public IActionResult Post(PostLeaveHistoryDTO dto)
        {
            var leavehistory = new Leavehistory
            {
                EmployeeId = dto.EmployeeId,
                TypeOfLeave=dto.TypeOfLeave,
                NoOfDays=dto.NoOfDays,
                FromDate=dto.FromDate,
                ToDate=dto.ToDate,
                Comments=dto.Comments,
                IsApproved=dto.IsApproved,
                IsDeleted=dto.IsDeleted,
                CreatedBy=dto.CreatedBy,
                CreatedDate=dto.CreatedDate,
                ModifiedBy=dto.ModifiedBy,
                ModifiedDate=dto.ModifiedDate,
            };
            _db.Leavehistories.Add(leavehistory);
            _db.SaveChanges();
            return Ok();

        }

        [HttpPut("{id:long}")]
        public IActionResult Put(PutLeaveHistoryDTO dto) 
        {
            var leavehistory = new Leavehistory
            {
                Id = dto.Id,
                EmployeeId = dto.EmployeeId,
                TypeOfLeave = dto.TypeOfLeave,
                NoOfDays = dto.NoOfDays,
                FromDate = dto.FromDate,
                ToDate = dto.ToDate,
                Comments = dto.Comments,
                IsApproved = dto.IsApproved,
                IsDeleted = dto.IsDeleted,
                CreatedBy = dto.CreatedBy,
                CreatedDate = dto.CreatedDate,
                ModifiedBy = dto.ModifiedBy,
                ModifiedDate = dto.ModifiedDate,
            };
            _db.Leavehistories.Update(leavehistory);
            _db.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id:long}")]
        public IActionResult Delete(int id)
        {
            var leavehistory = _db.Leavehistories.FirstOrDefault(x => x.Id == id);
            _db.Leavehistories.Remove(leavehistory);
            _db.SaveChanges();  
            return Ok();
        }
    }
}
