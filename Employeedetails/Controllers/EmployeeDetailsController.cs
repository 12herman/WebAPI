using Employeedetails.DTO.Employeedetail;
using Employeedetails.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace Employeedetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeDetailsController : ControllerBase
    {

        private readonly QosteqEmployeeContext _db;

        public EmployeeDetailsController(QosteqEmployeeContext db)
        {
            _db = db;
        }

        //[HttpGet]
        //public IActionResult Get()
        //{
        //    List<Employeedetail> employeedetails = new List<Employeedetail>();
        //    employeedetails = _db.Employeedetails.ToList();
        //    return Ok(employeedetails);
        //}



        [HttpGet]
        public IActionResult Get()
        {
            var employeeDetails = _db.Employeedetails
                                    .Include(e => e.OfficeLocation)
                                    .Include(e => e.Department)
                                    .Include(e => e.Addresses)
                                    .Include(e => e.Accountdetails)
                                    .Include(e => e.Roledetails)
                                    .ThenInclude(e => e.Role)
                                    .ToList();
            var employeeDTO = employeeDetails.Select(e => new GetEmpDetailDTO
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Gender = e.Gender,
                PersonalEmail = e.PersonalEmail,
                OfficeEmail = e.OfficeEmail,
                MobileNumber = e.MobileNumber,
                DateOfBirth = e.DateOfBirth,
                DateOfJoin = e.DateOfJoin,
                BloodGroup = e.BloodGroup,
                AlternateContactNo = e.AlternateContactNo,
                ContactPersonName = e.ContactPersonName,
                Relationship = e.Relationship,
                MaritalStatus = e.MaritalStatus,
                DepartmentId = new GetDepartmentEmpDetailDTO
                {
                    Id = e.Department.Id,
                    DepartmentName = e.Department.DepartmentName,
                    Isdeleted = e.Department.Isdeleted,
                    //CreatedBy = e.Department.CreatedBy,
                    //CreatedDate = e.Department.CreatedDate,
                    //ModifiedBy = e.Department.ModifiedBy,
                    //ModifiedDate = e.Department.ModifiedDate,
                },
                OfficeLocationId = new GetLocationEmpDetailDTO
                {
                    Id = e.OfficeLocation.Id,
                    Address = e.OfficeLocation.Address,
                    City = e.OfficeLocation.City,
                    State = e.OfficeLocation.State,
                    Country = e.OfficeLocation.Country,
                    Officename = e.OfficeLocation.Officename,
                    Isdeleted = e.IsDeleted,
                    //CreatedBy = e.OfficeLocation.CreatedBy,
                    //CreatedDate = e.OfficeLocation.CreatedDate,
                    //ModifiedBy = e.OfficeLocation.ModifiedBy,
                    //ModifiedDate = e.OfficeLocation.ModifiedDate,
                },
                RoleDetails = e.Roledetails.Select(roledetail => new GetRoleDetailsEmpDetailDTO
                {
                    Id = roledetail.Id,
                    RoleId = roledetail.RoleId,
                    RoleName = roledetail.Role?.RollName,
                    EmployeeId = roledetail.EmployeeId,
                    Isdeleted =roledetail.Isdeleted
                    //CreatedBy = roledetail.CreatedBy,
                    //CreatedDate = roledetail.CreatedDate,
                    //ModifiedBy = roledetail.ModifiedBy,
                    //ModifiedDate = roledetail.ModifiedDate,
                }).ToList(),
                AccountDetails = e.Accountdetails.Select(accountDetail => new GetEmpAccountDetailsDTO
                {
                    Id = accountDetail.Id,
                    AccountNumber = accountDetail.AccountNumber,
                    BankLocation = accountDetail.BankLocation,
                    BankName = accountDetail.BankName,
                    BranchName = accountDetail.BranchName,
                    EmployeeId = accountDetail.EmployeeId,
                    Ifsc = accountDetail.Ifsc,
                    Isdeleted = accountDetail.Isdeleted,
                    //CreatedBy = accountDetail.CreatedBy,
                    //CreatedDate = accountDetail.CreatedDate,
                    //ModifiedDate = accountDetail.ModifiedDate,
                    //ModifiedBy = accountDetail.ModifiedBy,
                }).ToList(),
                LastWorkDate = e.LastWorkDate,
                IsDeleted = e.IsDeleted,
                CreatedBy = e.CreatedBy,
                CreatedDate = e.CreatedDate,
                ModifiedBy = e.ModifiedBy,
                ModifiedDate = e.ModifiedDate,
            }).ToList();

            return Ok(employeeDTO);
        }

        [HttpPost]
        public IActionResult Post(PostEmpDetailDTOCheck employeedetail)
        {
            //var accountDetails = _db.Accountdetails;
            //var addresses = _db.Addresses;
            //var roleDetails = _db.Roledetails;
            //var empAccsessories = _db.Employeeaccessories;
            //var employeeHolidays = _db.Employeeholidays;
            //var leaderAndEmployees = _db.Leaderandemployees;
            //var salaries = _db.Salaries;

            Employeedetail employeedetail1s = new Employeedetail
            {
                FirstName = employeedetail.FirstName,
                LastName = employeedetail.LastName,
                Gender = employeedetail.Gender,
                PersonalEmail = employeedetail.PersonalEmail,
                OfficeEmail = employeedetail.OfficeEmail,
                MobileNumber = employeedetail.MobileNumber,
                DateOfBirth = employeedetail.DateOfBirth,
                DateOfJoin = employeedetail.DateOfJoin,
                BloodGroup = employeedetail.BloodGroup,
                AlternateContactNo = employeedetail.AlternateContactNo,
                ContactPersonName = employeedetail.ContactPersonName,
                Relationship = employeedetail.Relationship,
                MaritalStatus = employeedetail.MaritalStatus,
                OfficeLocationId = employeedetail.OfficeLocationId,
                DepartmentId = employeedetail.DepartmentId,
                IsDeleted = employeedetail.IsDeleted,

            };
            _db.Add(employeedetail1s);
            _db.SaveChanges();
            /*
            Accountdetail accountdetail = new Accountdetail
            {
                EmployeeId = employeedetail1s.Id,
            };
            _db.Add(accountdetail);
            _db.SaveChanges();
            // Use ReferenceHandler.Preserve to prevent circular reference exception
            var jsonOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };
            // Serialize the result using the configured options
            var jsonResult = JsonSerializer.Serialize(employeedetail1s, jsonOptions);
            return Ok(jsonResult);
            */
            return Ok(employeedetail1s);
        }

        [HttpPut("{id:long}")]
        public IActionResult Put(long id,PutEmployeeDetailDTO employeedetail)
        {
            var emp = _db.Employeedetails.Find(id);
           
            emp.Id = employeedetail.Id;
            emp.FirstName = employeedetail.FirstName;
            emp.Gender = employeedetail.Gender;
            emp.LastName = employeedetail.LastName;
            emp.PersonalEmail = employeedetail.PersonalEmail;
            emp.OfficeEmail = employeedetail.OfficeEmail;
            emp.MobileNumber = employeedetail.MobileNumber;
            emp.DateOfBirth = employeedetail.DateOfBirth;
            emp.DateOfJoin = employeedetail.DateOfJoin;
            emp.BloodGroup = employeedetail.BloodGroup;
            emp.AlternateContactNo = employeedetail.AlternateContactNo;
            emp.ContactPersonName = employeedetail.ContactPersonName;
            emp.Relationship = employeedetail.Relationship;
            emp.MaritalStatus = employeedetail.MaritalStatus;
            emp.OfficeLocationId = employeedetail.OfficeLocationId;
            emp.DepartmentId = employeedetail.DepartmentId;
            emp.CreatedBy = employeedetail.CreatedBy;
            emp.CreatedDate = employeedetail.CreatedDate;
            emp.ModifiedBy = employeedetail.ModifiedBy;
            emp.ModifiedDate = employeedetail.ModifiedDate;
            emp.IsDeleted = employeedetail.IsDeleted;
            _db.Employeedetails.Update(emp);
            _db.SaveChanges();
            return Ok();
        }


        [HttpDelete("{id:long}")]
        public IActionResult Delete(long id)
        {
            var emp = _db.Employeedetails.FirstOrDefault(x => x.Id == id);
            if (emp == null)
            {
                return NotFound($"Employee with ID {id} not found.");
            }

            // Manually delete related records in the roledetails table
            var roleDetails = _db.Roledetails.Where(rd => rd.EmployeeId == id);
            _db.Roledetails.RemoveRange(roleDetails);

            // Manually delete related records in the address table
            var addresses = _db.Addresses.Where(a => a.EmployeeId == id);
            _db.Addresses.RemoveRange(addresses);

            // Manually delete related records in the salary table
            var salaries = _db.Salaries.Where(s => s.EmployeeId == id);
            _db.Salaries.RemoveRange(salaries);

            // Manually delete related records in the leaderandemployee table
            var leaderAndEmployees = _db.Leaderandemployees.Where(le => le.EmployeeId == id || le.LeaderId == id).ToList();
            _db.Leaderandemployees.RemoveRange(leaderAndEmployees);

            // Manually delete related records in the employeeholiday table
            var employeeHolidays = _db.Employeeholidays.Where(eh => eh.EmployeeId == id);
            _db.Employeeholidays.RemoveRange(employeeHolidays);

            // Manually delete related records in the accountdetails table
            var accountDetails = _db.Accountdetails.Where(a => a.EmployeeId == id);
            _db.Accountdetails.RemoveRange(accountDetails);

            // Manually delete related records in the employeeaccessories table
            //var accessories = _db.Employeeaccessories.Where(a => a.EmployeeId == id);
            //_db.Employeeaccessories.RemoveRange(accessories);

            // Remove the employee
            _db.Employeedetails.Remove(emp);
            _db.SaveChanges();

            return Ok();
        }






        //[HttpPost]
        //public IActionResult Post( PostEmployeedetailDTO employeedetails)
        //{

        //    var employeeEntity = new Employeedetail
        //    {
        //        Id = employeedetails.Id,
        //        FirstName = employeedetails.FirstName,
        //        LastName = employeedetails.LastName,
        //        PersonalEmail = employeedetails.PersonalEmail,
        //        OfficeEmail = employeedetails.OfficeEmail,
        //        MobileNumber = employeedetails.MobileNumber,
        //        DateOfBirth = employeedetails.DateOfBirth,
        //        DateOfJoin = employeedetails.DateOfJoin,
        //        BloodGroup = employeedetails.BloodGroup,
        //        AlternateContactNo = employeedetails.AlternateContactNo,
        //        ContactPersonName = employeedetails.ContactPersonName,
        //        Relationship = employeedetails.Relationship,
        //        MaritalStatus = employeedetails.MaritalStatus,
        //        OfficeLocationId = employeedetails.OfficeLocationId,
        //        DepartmentId = employeedetails.DepartmentId,
        //    };

        //    var accountdetails = new Accountdetail
        //    {
        //        EmployeeId = employeedetails.Id
        //    };

        //    var addresses = new Address
        //    {
        //        EmployeeId = employeedetails.Id
        //    };

        //    var employeeaccessories = new Employeeaccessory
        //    {
        //        EmployeeId = employeedetails.Id
        //    };

        //    var employeeholidays = new Employeeholiday
        //    {
        //        EmployeeId = employeedetails.Id
        //    };

        //    var leaderandemployeeEmployees = new Leaderandemployee
        //    {
        //        EmployeeId = employeedetails.Id
        //    };

        //    var roledetails = new Roledetail
        //    {
        //        EmployeeId = employeedetails.Id
        //    };


        //    _db.Employeedetails.Add(employeeEntity);
        //    _db.Accountdetails.Add(accountdetails);
        //    _db.Addresses.Add(addresses);
        //    _db.Employeeaccessories.Add(employeeaccessories);
        //    _db.Employeeholidays.Add(employeeholidays);
        //    _db.Leaderandemployees.Add(leaderandemployeeEmployees);
        //    _db.Roledetails.Add(roledetails);

        //    _db.SaveChanges();
        //    return Ok(employeedetails);

        //}
    }
}
