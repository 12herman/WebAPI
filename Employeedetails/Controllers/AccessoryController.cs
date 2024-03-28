using Employeedetails.DTO.Accessory;
using Employeedetails.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employeedetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessoryController : ControllerBase
    {
        public readonly QosteqEmployeeContext _db;
        public AccessoryController(QosteqEmployeeContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<Accessory> accessories = new List<Accessory>();
            accessories = _db.Accessories.ToList();
            return Ok(accessories);
        }
        [HttpPost]
        public IActionResult Post(PostAccessoryDTO accessoryDTO)
        {
            var accessory = new Accessory
            {
                Name = accessoryDTO.Name,
                CreatedBy = accessoryDTO.CreatedBy,
                CreatedDate = accessoryDTO.CreatedDate,
                ModifiedBy = accessoryDTO.ModifiedBy,
                ModifiedDate = accessoryDTO.ModifiedDate,
                Isdeleted = accessoryDTO.Isdeleted,
            };

            _db.Accessories.Add(accessory);
            _db.SaveChanges();
            return Ok(accessory);
        }
        [HttpPut("{id:int}")]
        public IActionResult Put(PutAccessoryDTO accessoryDTO)
        {
            var accessory = new Accessory
            {
                Id = accessoryDTO.Id,
                Name = accessoryDTO.Name,
                CreatedBy = accessoryDTO.CreatedBy,
                CreatedDate = accessoryDTO.CreatedDate,
                ModifiedBy = accessoryDTO.ModifiedBy,
                ModifiedDate = accessoryDTO.ModifiedDate,
                Isdeleted = accessoryDTO.Isdeleted,
            };
            _db.Accessories.Update(accessory);
            _db.SaveChanges();
            return Ok(accessory);
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var accessory = _db.Accessories.FirstOrDefault(x=> x.Id == id);
            _db.Accessories.Remove(accessory);
            _db.SaveChanges();
            return Ok();
        }
    }
}
