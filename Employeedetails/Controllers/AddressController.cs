using Employeedetails.DTO.Address;
using Employeedetails.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employeedetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        public readonly QosteqEmployeeContext _db;

        public AddressController(QosteqEmployeeContext db)
        {
            _db = db;   
        }

        [HttpGet]
        public ActionResult Get() 
        {
            List<Address> addresses = new List<Address>();
            addresses = _db.Addresses.ToList();
            return Ok(addresses);
        }
        [HttpPost]
        public IActionResult Post([FromBody] PostAddressDTO address)
        {
            var add = new Address
            { 
              EmployeeId = address.EmployeeId,
              Address1 = address.Address1,
              City = address.City,
              Country = address.Country,
              State = address.State,
              PostalCode = address.PostalCode,
              Type = address.Type,
              CreatedBy = address.CreatedBy,
              CreatedDate = address.CreatedDate,
              ModifiedBy = address.ModifiedBy,
              ModifiedDate = address.ModifiedDate,
              Isdeleted = address.Isdeleted,
            };
            _db.Addresses.Add(add);
            _db.SaveChanges();
            return Ok(add);
        }

        [HttpPut("{id:long}")]
        public IActionResult Put(long id, PutAddressDTO address) 
        {
            var add = _db.Addresses.Find(id);

            add.Id = address.Id;
            add.EmployeeId = address.EmployeeId;
            add.Address1 = address.Address1;
            add.City = address.City;
            add.State = address.State;
            add.Country = address.Country;
            add.PostalCode= address.PostalCode;
            add.Type= address.Type;
            add.CreatedDate= address.CreatedDate;
            add.CreatedBy = address.CreatedBy;
            add.ModifiedBy = address.ModifiedBy;
            add.ModifiedDate = address.ModifiedDate;
            add.Isdeleted = address.Isdeleted;
         
            _db.Addresses.Update(add);
            _db.SaveChanges();
            return Ok(add);
        }

        [HttpDelete("{id:long}")]
        public IActionResult Delete(long id)
        {
            var add = _db.Addresses.FirstOrDefault(x => x.Id == id);
            _db.Addresses.Remove(add);
            _db.SaveChanges();
            return Ok();
        }
    }
}
