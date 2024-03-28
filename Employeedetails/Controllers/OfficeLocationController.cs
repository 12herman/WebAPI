using Employeedetails.DTO.OfficeLocation;
using Employeedetails.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employeedetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeLocationController : ControllerBase
    {
        public readonly QosteqEmployeeContext _db;
        public OfficeLocationController(QosteqEmployeeContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<Officelocation> officelocations = new List<Officelocation>();
            officelocations = _db.Officelocations.ToList();
            return Ok(officelocations);
        }

        [HttpPost]
        public IActionResult Post(PostOfficeLocationDTO postOfficeLocationDTO)
        {
            var officeLo = new Officelocation
            {
                Officename = postOfficeLocationDTO.Officename,
                Address = postOfficeLocationDTO.Address,
                City = postOfficeLocationDTO.City,
                Country = postOfficeLocationDTO.Country,
                State = postOfficeLocationDTO.State,
                CreatedBy = postOfficeLocationDTO.CreatedBy,
                CreatedDate = postOfficeLocationDTO.CreatedDate,
                ModifiedBy = postOfficeLocationDTO.ModifiedBy,
                ModifiedDate = postOfficeLocationDTO.ModifiedDate,
                Isdeleted = postOfficeLocationDTO.Isdeleted,
            };
            _db.Add(officeLo);
            _db.SaveChanges();
            return Ok(officeLo);
        }

        //[HttpPut("{id:int}")]
        //public IActionResult Put(int id,PutOfficeLocationDTO putOfficeLocationDTO)
        //{

        //    var officeLo = new Officelocation
        //    {

        //        Id = putOfficeLocationDTO.Id,
        //        Officename=putOfficeLocationDTO.Officename,
        //        Address = putOfficeLocationDTO.Address,
        //        City = putOfficeLocationDTO.City,
        //        Country = putOfficeLocationDTO.Country,
        //        State = putOfficeLocationDTO.State,
        //        //CreatedBy = putOfficeLocationDTO.CreatedBy,
        //        //CreatedDate = putOfficeLocationDTO.CreatedDate,
        //        //ModifiedBy = putOfficeLocationDTO.ModifiedBy,
        //        //ModifiedDate = putOfficeLocationDTO.ModifiedDate,
        //    };
        //    _db.Update(officeLo);
        //    _db.SaveChanges();
        //    return Ok(officeLo);
        //}

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, PutOfficeLocationDTO putOfficeLocationDTO)
        {
            var officeLo = new Officelocation
            {
                Id = putOfficeLocationDTO.Id,
                Officename = putOfficeLocationDTO.Officename,
                Address = putOfficeLocationDTO.Address,
                City = putOfficeLocationDTO.City,
                Country = putOfficeLocationDTO.Country,
                State = putOfficeLocationDTO.State,
                Isdeleted = putOfficeLocationDTO.Isdeleted,
                //CreatedBy = putOfficeLocationDTO.CreatedBy,
                //CreatedDate = putOfficeLocationDTO.CreatedDate,
                //ModifiedBy = putOfficeLocationDTO.ModifiedBy,
                //ModifiedDate = putOfficeLocationDTO.ModifiedDate,
            };

            _db.Update(officeLo);
            _db.SaveChanges();

            return Ok(officeLo);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var officeLocation = _db.Officelocations.FirstOrDefault(o => o.Id == id);
            _db.Officelocations.Remove(officeLocation);
            _db.SaveChanges();
            return Ok();
        }
    }
}
