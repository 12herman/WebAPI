using Employeedetails.DTO.Role;
using Employeedetails.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employeedetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        public readonly QosteqEmployeeContext _db;
        public RoleController(QosteqEmployeeContext db) 
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Role> role = new List<Role>();
            role = _db.Roles.ToList();
            return Ok(role);
        }

        [HttpPost]
        public IActionResult Post(PostRoleDTO roles)
        {
          var roleEntity = new Role
          { 
              RollName = roles.RollName,
              Isdeleted = roles.Isdeleted,
              CreatedDate = roles.CreatedDate,
              CreatedBy = roles.CreatedBy,
              ModifiedDate = roles.ModifiedDate,
              ModifiedBy = roles.ModifiedBy
          };
            _db.Roles.Add(roleEntity);
            _db.SaveChanges();

            return Ok();
        }

        [HttpPut("{id:long}")]
        public IActionResult Put(PutRoleDTO roles)
        {
            var roleEntity = new Role
            {
                Id = roles.Id,
                RollName = roles.RollName,
                Isdeleted = roles.Isdeleted,
                CreatedDate = roles.CreatedDate,
                CreatedBy = roles.CreatedBy,
                ModifiedDate = roles.ModifiedDate,
                ModifiedBy = roles.ModifiedBy
            };
            _db.Roles.Update(roleEntity);
            _db.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var role = _db.Roles.FirstOrDefault(x=> x.Id == id);
            _db.Roles.Remove(role);
            _db.SaveChanges();
            return Ok();
        }
    }
}
