using Employeedetails.DTO.LeaveTable;
using Employeedetails.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employeedetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTableController : ControllerBase
    {
        public readonly QosteqEmployeeContext _db;

        public LeaveTableController(QosteqEmployeeContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Leavetable> list = new List<Leavetable>();
            list = _db.Leavetables.ToList();
            return Ok(list);
        }
        [HttpPost]
        public IActionResult Post(PostLeaveTableDTO leavedto)
        {
            var leavetable = new Leavetable 
            { 
                SickLeave = leavedto.SickLeave,
                CasualLeave = leavedto.CasualLeave,
                LeaveAvailed = leavedto.LeaveAvailed,
                Total = leavedto.Total,
                CreatedBy = leavedto.CreatedBy,
                CreatedDate = leavedto.CreatedDate,
                ModifiedBy = leavedto.ModifiedBy,
                ModifiedDate = leavedto.ModifiedDate
            };
            _db.Add(leavetable);
            _db.SaveChanges();
            return Ok();
        }

        [HttpPut ("{id:int}")]
        public IActionResult Put( PutLeaveTableDTO leavedto) 
        {
            var leavetable = new Leavetable
            {
                Id= leavedto.Id,
                SickLeave = leavedto.SickLeave,
                CasualLeave = leavedto.CasualLeave,
                LeaveAvailed = leavedto.LeaveAvailed,
                Total = leavedto.Total,
                CreatedBy = leavedto.CreatedBy,
                CreatedDate = leavedto.CreatedDate,
                ModifiedBy = leavedto.ModifiedBy,
                ModifiedDate = leavedto.ModifiedDate
            };
            _db.Update(leavetable);
            _db.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id) 
        {
           var leavetable = _db.Leavetables.FirstOrDefault(data => data.Id == id);
            _db.Leavetables.Remove(leavetable);
            _db.SaveChanges();
            return Ok();
        }
    }
}
