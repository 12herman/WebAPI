using Employeedetails.DTO.EmployeeLeaveHistory;
using Employeedetails.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employeedetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeLeaveHistoryController : ControllerBase
    {
        public readonly QosteqEmployeeContext _db;

        public EmployeeLeaveHistoryController(QosteqEmployeeContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        { 
            List<Employeeleavehistory> employeeleavehistory = new List<Employeeleavehistory>();
            employeeleavehistory = _db.Employeeleavehistories.ToList();
            return Ok(employeeleavehistory);
        }

        [HttpPost]
        public IActionResult Post(PostEmployeeLeaveHistoryDTO dto)
        {
            var leavehistory = new Employeeleavehistory
            {
                EmployeeId = dto.EmployeeId,
                LeaveType = dto.LeaveType,
                Fromdate = dto.Fromdate,
                Todate = dto.Todate,
                NumberOfDays = dto.NumberOfDays,
                Comments = dto.Comments,
                HrIsApproved = dto.HrIsApproved,
                HrIsRejected = dto.HrIsRejected,
                LeaderIsApproved = dto.LeaderIsApproved,
                LeaderIsRejected = dto.LeaderIsRejected,
                RejectedComments = dto.RejectedComments,
                IsDeleted = dto.IsDeleted,
                CreatedBy = dto.CreatedBy,
                ModifiedBy = dto.ModifiedBy, 
            };
            _db.Add(leavehistory);
            _db.SaveChanges();
            return Ok(leavehistory);
        }

        [HttpPut ("{id:int}")]
        public IActionResult Put(PutEmployeeLeaveHistoryDTO dto) 
        {
            var leavehistory = new Employeeleavehistory
            {
                Id = dto.Id,
                EmployeeId = dto.EmployeeId,
                LeaveType = dto.LeaveType,
                Fromdate = dto.Fromdate,
                Todate = dto.Todate,
                NumberOfDays = dto.NumberOfDays,
                Comments = dto.Comments,
                HrIsApproved = dto.HrIsApproved,
                HrIsRejected = dto.HrIsRejected,
                RejectedComments = dto.RejectedComments,
                LeaderIsApproved = dto.LeaderIsApproved,
                LeaderIsRejected = dto.LeaderIsRejected,
                IsDeleted = dto.IsDeleted,
                CreatedBy = dto.CreatedBy,
                ModifiedBy = dto.ModifiedBy,
                CreatedDate = dto.CreatedDate,
                ModifiedDate = dto.ModifiedDate,
            };
            _db.Update(leavehistory);
            _db.SaveChanges();
            return Ok(leavehistory);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var employeeleave = _db.Employeeleavehistories.FirstOrDefault(e => e.Id == id);
            _db.Employeeleavehistories.Remove(employeeleave);
            _db.SaveChanges();
            return Ok();
        }

    }
}
