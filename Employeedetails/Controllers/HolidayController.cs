using Employeedetails.DTO.Holiday;
using Employeedetails.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Employeedetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolidayController : ControllerBase
    {
        public readonly QosteqEmployeeContext _db;

        public HolidayController(QosteqEmployeeContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            //List<Holiday> holidays = new List<Holiday>();
            //holidays = _db.Holidays.ToList();
            //return Ok(holidays);
            //var holidays = _db.Holidays.Include(e =>e.OfficeLocationId).ToList();

            var holidays = from Holidays in _db.Holidays
                           join Officelocation in _db.Officelocations on Holidays.OfficeLocationId equals Officelocation.Id
                           select new
                           {
                               Id = Holidays.Id,
                               officelocationId= Holidays.OfficeLocationId,
                               Officelocation = Officelocation.Officename,
                               holidayName = Holidays.HolidayName,
                               date = Holidays.Date,
                               createdDate = Holidays.CreatedDate,
                               createdBy = Holidays.CreatedBy,
                               modifiedDate = Holidays.ModifiedDate,
                               modifiedBy = Holidays.ModifiedBy,
                               isdeleted = Holidays.Isdeleted
                           };

            return Ok(holidays);
                
        }
        [HttpPost]
        public IActionResult Post(PostHolidayDTO holidayDTO)
        {
            var holiday = new Holiday
            {
                OfficeLocationId = holidayDTO.OfficeLocationId,
                HolidayName = holidayDTO.HolidayName,
                Date = holidayDTO.Date,
                CreatedBy = holidayDTO.CreatedBy,
                CreatedDate = holidayDTO.CreatedDate,
                ModifiedBy = holidayDTO.ModifiedBy,
                ModifiedDate = holidayDTO.ModifiedDate,
                Isdeleted = holidayDTO.IsDeleted
            };
            _db.Holidays.Add(holiday);
            _db.SaveChanges();
            return Ok(holiday);
        }
        [HttpPut("{id:int}")]
        public IActionResult Put(PutHolidayDTO holidayDTO)
        {
            var holiday = new Holiday
            {
                Id = holidayDTO.Id,
                OfficeLocationId = holidayDTO.OfficeLocationId,
                HolidayName = holidayDTO.HolidayName,
                Date = holidayDTO.Date,
                CreatedBy = holidayDTO.CreatedBy,
                CreatedDate = holidayDTO.CreatedDate,
                ModifiedBy = holidayDTO.ModifiedBy,
                ModifiedDate = holidayDTO.ModifiedDate,
                Isdeleted = holidayDTO.IsDeleted
            };
            _db.Holidays.Update(holiday);
            _db.SaveChanges();
            return Ok(holiday);
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var holiday = _db.Holidays.FirstOrDefault(x => x.Id == id);
            _db.Holidays.Remove(holiday);
            _db.SaveChanges();
            return Ok();
        }
    }
}
