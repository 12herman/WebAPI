using Employeedetails.DTO.LeaderAndEmployee;
using Employeedetails.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employeedetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaderAndEmployeeController : ControllerBase
    {
        public readonly QosteqEmployeeContext _db;
        public LeaderAndEmployeeController(QosteqEmployeeContext db) 
        {
          _db = db;
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<Leaderandemployee> leaderandemployees = new List<Leaderandemployee>();
            leaderandemployees = _db.Leaderandemployees.ToList();
            return Ok(leaderandemployees);
        }
        [HttpPost]
        public IActionResult Post(PostLeaderAndEmployee putLeaderAndEmployee)
        {
            var leaderEmployee = new Leaderandemployee 
            {
             EmployeeId = putLeaderAndEmployee.EmployeeId,
             LeaderId = putLeaderAndEmployee.LeaderId,
             HrManagerId = putLeaderAndEmployee.HrManagerId,
             CreatedBy = putLeaderAndEmployee.CreatedBy,
             CreatedDate = putLeaderAndEmployee.CreatedDate,
             ModifiedBy = putLeaderAndEmployee.ModifiedBy,
             ModifiedDate = putLeaderAndEmployee.ModifiedDate,
             Isdeleted = putLeaderAndEmployee.IsDeleted
            };
            _db.Add(leaderEmployee);
            _db.SaveChanges();
            return Ok(leaderEmployee);
        }
        [HttpPut("{id:long}")]
        public IActionResult Put(long id, PutLeaderAndEmployee putLeaderAndEmployee)
        {
            var leaderEmp = _db.Leaderandemployees.FirstOrDefault(x=>x.Id == id);

            leaderEmp.EmployeeId = putLeaderAndEmployee.EmployeeId;
            leaderEmp.LeaderId = putLeaderAndEmployee.LeaderId;
            leaderEmp.HrManagerId = putLeaderAndEmployee.HrManagerId;
            leaderEmp.ModifiedDate = putLeaderAndEmployee.ModifiedDate;
            leaderEmp.ModifiedBy = putLeaderAndEmployee.ModifiedBy;
            leaderEmp.Isdeleted = putLeaderAndEmployee.IsDeleted;
            _db.Update(leaderEmp);
            _db.SaveChanges();
            return Ok(leaderEmp);

        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(long id)
        {
            var leaderEmpl = _db.Leaderandemployees.FirstOrDefault(x => x.Id == id);
            _db.Leaderandemployees.Remove(leaderEmpl);
            _db.SaveChanges();
            return Ok(leaderEmpl);
        }
    }
}
