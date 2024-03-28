using Employeedetails.DTO.EmployeeHoliday;
using Employeedetails.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Employeedetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeHolidayController : ControllerBase
    {
        public readonly QosteqEmployeeContext _db;

        public EmployeeHolidayController(QosteqEmployeeContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Get()
        {
            //List<Employeeholiday> employeeholidays = new List<Employeeholiday>();
            //employeeholidays = _db.Employeeholidays.ToList();
            //return Ok(employeeholidays);
            var employeeleave = from Employee in _db.Employeedetails
                                join EmployeeLeave in _db.Employeeholidays on Employee.Id equals EmployeeLeave.EmployeeId
                                select new
                                {
                                    Id= EmployeeLeave.Id,
                                    EmployeeName = Employee.FirstName+ " " + Employee.LastName,
                                    EmployeeId = Employee.Id,
                                    EmployeeData= Employee,
                                    SickLeave= EmployeeLeave.SickLeave,
                                    CasualLeave= EmployeeLeave.CasualLeave,
                                    Total= EmployeeLeave.Total,
                                    LeaveAvailed= EmployeeLeave.LeaveAvailed,
                                    isdeleted = EmployeeLeave.Isdeleted,
                                    CreatedBy=EmployeeLeave.CreatedBy,
                                    CreatedDate=EmployeeLeave.CreatedDate,
                                    ModifiedBy = EmployeeLeave.ModifiedBy,
                                    ModifiedDate = EmployeeLeave.ModifiedDate,
                                };
            return Ok(employeeleave);
        }
        [HttpPost]
        public IActionResult Post(PostEmployeeHolidayDTO employee)
        {
            var emholiday = new Employeeholiday
            { 
              EmployeeId = employee.EmployeeId,
              SickLeave = employee.SickLeave,
              CasualLeave = employee.CasualLeave,
              Total = employee.Total,
              LeaveAvailed = employee.LeaveAvailed,
              CreatedBy = employee.CreatedBy,
              CreatedDate = employee.CreatedDate,
              ModifiedBy = employee.ModifiedBy,
              ModifiedDate = employee.ModifiedDate,
              Isdeleted = employee.IsDeleted
            };
            _db.Employeeholidays.Add(emholiday);
            _db.SaveChanges();
            return Ok(emholiday);
        }
        [HttpPut("{id:int}")]
        public IActionResult Put(PutEmployeeHolidayDTO employee)
        {
            var emholiday = new Employeeholiday
            {
                Id = employee.Id,
                EmployeeId = employee.EmployeeId,
                SickLeave = employee.SickLeave,
                CasualLeave = employee.CasualLeave,
                Total = employee.Total,
                LeaveAvailed = employee.LeaveAvailed,
                CreatedBy = employee.CreatedBy,
                CreatedDate = employee.CreatedDate,
                ModifiedBy = employee.ModifiedBy,
                ModifiedDate = employee.ModifiedDate,
                Isdeleted = employee.IsDeleted
            };
            _db.Employeeholidays.Update(emholiday);
            _db.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var emholiday = _db.Employeeholidays.FirstOrDefault(e => e.Id == id);

            _db.Employeeholidays.Remove(emholiday);
            _db.SaveChanges();
            return Ok();
        }
    }
}
