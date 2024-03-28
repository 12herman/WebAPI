//using Employeedetails.Models;

//namespace Employeedetails.DTO.Employeedetail
//{
//    public class PostEmployeedetailDTO
//    {
//        public long Id { get; set; }
//        public string? FirstName { get; set; }

//        public string? LastName { get; set; }

//        public string? PersonalEmail { get; set; }

//        public string? OfficeEmail { get; set; }

//        public string MobileNumber { get; set; } = null!;

//        public DateOnly DateOfBirth { get; set; }

//        public DateOnly DateOfJoin { get; set; }

//        public string? BloodGroup { get; set; }

//        public string? AlternateContactNo { get; set; }

//        public string? ContactPersonName { get; set; }

//        public string? Relationship { get; set; }

//        public string? MaritalStatus { get; set; }

//        public int OfficeLocationId { get; set; }

//        public int DepartmentId { get; set; }

//        public DateOnly? LastWorkDate { get; set; }

//        public bool? IsDeleted { get; set; }


//        public DateTime? CreatedDate { get; set; }

//        public string? CreatedBy { get; set; }

//        public DateTime? ModifiedDate { get; set; }

//        public string? ModifiedBy { get; set; }

//        //public List<AccountdetailDTO> Accountdetails { get; set; } = new List<AccountdetailDTO>();

//        //public List<AddressDTO> Addresses { get; set; } = new List<AddressDTO>();

//        //public List<EmployeeaccessoryDTO> Employeeaccessories { get; set; } = new List<EmployeeaccessoryDTO>();

//        //public List<EmployeeholidayDTO> Employeeholidays { get; set; } = new List<EmployeeholidayDTO>();

//        //public List<LeaderandemployeeDTO> LeaderandemployeeEmployees { get; set; } = new List<LeaderandemployeeDTO>();

//        //public List<RoledetailDTO> Roledetails { get; set; } = new List<RoledetailDTO>();

//    }


//    public class AccountdetailDTO
//    {
//        public long Id { get; set; }
//        public long? EmployeeId { get; set; }

//        public AccountdetailDTO(PostEmployeedetailDTO postEmployeedetailDTO)
//        {
//            EmployeeId = postEmployeedetailDTO.Id;
//        }
//    }



//    public class AddressDTO
//    {
//        public long Id { get; set; }

//        public long? EmployeeId { get; set; }

//        public AddressDTO(PostEmployeedetailDTO postEmployeedetailDTO) => EmployeeId = postEmployeedetailDTO.Id;

//    }



//    public class EmployeeaccessoryDTO
//    {
//        public long Id { get; set; }

//        public long? EmployeeId { get; set; }

//        public EmployeeaccessoryDTO(PostEmployeedetailDTO postEmployeedetailDTO)
//        {
//            EmployeeId = postEmployeedetailDTO.Id;
//        }
//    }



//    public class EmployeeholidayDTO
//    {
//        public int Id { get; set; }

//        public long? EmployeeId { get; set; }

//        public EmployeeholidayDTO(PostEmployeedetailDTO postEmployeedetailDTO)
//        {
//            EmployeeId = postEmployeedetailDTO.Id;
//        }
//    }



//    public class LeaderandemployeeDTO
//    {
//        public long Id { get; set; }

//        public long? EmployeeId { get; set; }

//        public LeaderandemployeeDTO(PostEmployeedetailDTO postEmployeedetailDTO)
//        {
//            EmployeeId = postEmployeedetailDTO.Id;
//        }
//    }



//    public class RoledetailDTO
//    {
//        public int Id { get; set; }
//        public long? EmployeeId { get; set; }

//        public RoledetailDTO(PostEmployeedetailDTO postEmployeedetailDTO)
//        {
//            EmployeeId = postEmployeedetailDTO.Id;
//        }
//    }



//    public class SalaryDTO
//    {
//        public long Id { get; set; }

//        public long? EmployeeId { get; set; }

//        public SalaryDTO(PostEmployeedetailDTO postEmployeedetailDTO)
//        {
//            EmployeeId = postEmployeedetailDTO.Id;
//        }
//    }

//}
