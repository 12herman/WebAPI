using Employeedetails.DTO.Department;
using Employeedetails.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employeedetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        public readonly QosteqEmployeeContext _db;
        public DepartmentController(QosteqEmployeeContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<Department> departments = new List<Department>();
            departments = _db.Departments.ToList();
            return Ok(departments);
        }

        [HttpPost]
        public IActionResult Post(PostDempartmentDTO department)
        {
            var departments = new Department
            {
                DepartmentName = department.DepartmentName,
                CreatedBy =department.CreatedBy,
                CreatedDate = department.CreatedDate,
                ModifiedBy =department.ModifiedBy,
                ModifiedDate = department.ModifiedDate,
                Isdeleted = department.Isdeleted,

            };
            _db.Departments.Add(departments);
            _db.SaveChanges();
            return Ok(departments);
        }
        [HttpPut("{id:int}")]
        public IActionResult Put(PutDepartmentDTO department)
        {
            var departments = new Department
            {
                Id = department.Id,
                DepartmentName = department.DepartmentName,
                CreatedBy = department.CreatedBy,
                CreatedDate = department.CreatedDate,
                ModifiedBy = department.ModifiedBy,
                ModifiedDate = department.ModifiedDate,
                Isdeleted = department.Isdeleted,
            };
            _db.Departments.Update(departments);
            _db.SaveChanges();
            return Ok(departments);
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var department = _db.Departments.FirstOrDefault(x=> x.Id == id);
            _db.Departments.Remove(department);
            _db.SaveChanges();
            return Ok();
        }

    }
}
