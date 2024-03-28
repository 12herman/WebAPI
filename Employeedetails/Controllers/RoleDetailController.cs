using Employeedetails.DTO.RoleDetails;
using Employeedetails.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employeedetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleDetailController : ControllerBase
    {
        public readonly QosteqEmployeeContext _db;

        public RoleDetailController(QosteqEmployeeContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Roledetail> roleDetail = new List<Roledetail>();
            roleDetail = _db.Roledetails.ToList();
            return Ok(roleDetail);
        }
        [HttpPost]
        public IActionResult Post(PostRoleDetailDTO roleDetailDTO)
        {
            var rollDetail = new Roledetail
            { 
                RoleId = roleDetailDTO.RoleId,
                EmployeeId = roleDetailDTO.EmployeeId,
                CreatedBy = roleDetailDTO.CreatedBy,
                CreatedDate = roleDetailDTO.CreatedDate,
                ModifiedBy = roleDetailDTO.ModifiedBy,
                ModifiedDate = roleDetailDTO.ModifiedDate,
                Isdeleted = roleDetailDTO.IsDeleted
            };

            _db.Roledetails.Add(rollDetail);
            _db.SaveChanges();
            return Ok(rollDetail);
        }
        [HttpPut ("{id:int}")]
        public IActionResult Put(PutRoleDetailDTO roleDetailDTO)
        {
            var rollDetail = new Roledetail
            {
                Id = roleDetailDTO.Id,
                RoleId = roleDetailDTO.RoleId,
                EmployeeId = roleDetailDTO.EmployeeId,
                CreatedBy = roleDetailDTO.CreatedBy,
                CreatedDate = roleDetailDTO.CreatedDate,
                ModifiedBy = roleDetailDTO.ModifiedBy,
                ModifiedDate = roleDetailDTO.ModifiedDate,
                Isdeleted = roleDetailDTO.IsDeleted
            };
            _db.Roledetails.Update(rollDetail);
            _db.SaveChanges();
            return Ok(rollDetail);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var roleDetail = _db.Roledetails.FirstOrDefault(r => r.Id == id);

            _db.Roledetails.Remove(roleDetail);
            _db.SaveChanges();
            return Ok();
        }
    }
}
