using Employeedetails.DTO.Salary;
using Employeedetails.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employeedetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryController : ControllerBase
    {
        public readonly QosteqEmployeeContext _db;
        public SalaryController(QosteqEmployeeContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            //List<Salary> salary = new List<Salary>();
            //salary = _db.Salaries.ToList();
            //return Ok(salary);
            var result = from Salary in _db.Salaries
                         join Employee in _db.Employeedetails on Salary.EmployeeId equals Employee.Id into employeeGroup
                         from Employee in employeeGroup.DefaultIfEmpty()
                         select new
                         {
                             Id = Salary.Id,
                             EmployeeId = Salary.EmployeeId,
                             EmployeeName = Employee != null ? Employee.FirstName + " " + Employee.LastName : null,
                             Ctc = Salary.Ctc,
                             GrossSalary = Salary.GrossSalary,
                             NetSalary = Salary.NetSalary,
                             SalaryDate = Salary.SalaryDate,
                             IsRevised = Salary.IsRevised,
                             CreatedDate = Salary.CreatedDate,
                             CreatedBy = Salary.CreatedBy,
                             ModifiedDate = Salary.ModifiedDate,
                             ModifiedBy = Salary.ModifiedBy,
                             IsDeleted = Salary.IsDeleted,

                         };
            return Ok(result.ToList());
        }
        [HttpPost]
        public IActionResult Post(PostSalaryDTO salaryDTO)
        {
            var salary = new Salary
            {
                EmployeeId = salaryDTO.EmployeeId,
                Ctc = salaryDTO.Ctc,
                GrossSalary = salaryDTO.GrossSalary,
                NetSalary = salaryDTO.NetSalary,
                SalaryDate = salaryDTO.SalaryDate,
                IsRevised = salaryDTO.IsRevised,
                CreatedBy = salaryDTO.CreatedBy,
                CreatedDate = salaryDTO.CreatedDate,
                ModifiedBy = salaryDTO.ModifiedBy,
                ModifiedDate = salaryDTO.ModifiedDate,
                IsDeleted = salaryDTO.IsDeleted
            };
            _db.Salaries.Add(salary);
            _db.SaveChanges();
            return Ok(salary);
        }

        [HttpPut("{id:long}")]
        public IActionResult Put(PutSalaryDTO salaryDTO)
        {
            var salary = new Salary
            {
                Id = salaryDTO.Id,
                EmployeeId = salaryDTO.EmployeeId,
                Ctc = salaryDTO.Ctc,
                GrossSalary = salaryDTO.GrossSalary,
                NetSalary = salaryDTO.NetSalary,
                SalaryDate = salaryDTO.SalaryDate,
                IsRevised = salaryDTO.IsRevised,
                CreatedBy = salaryDTO.CreatedBy,
                CreatedDate = salaryDTO.CreatedDate,
                ModifiedBy = salaryDTO.ModifiedBy,
                ModifiedDate = salaryDTO.ModifiedDate,
                IsDeleted = salaryDTO.IsDeleted
            };
            _db.Salaries.Update(salary);
            _db.SaveChanges();
            return Ok(salary);
        }

        [HttpDelete("{id:long}")]
        public IActionResult Delete(int id)
        {
            var salary = _db.Salaries.FirstOrDefault(s => s.Id == id);
            _db.Salaries.Remove(salary);
            _db.SaveChanges();
            return Ok();
        }
    }
}