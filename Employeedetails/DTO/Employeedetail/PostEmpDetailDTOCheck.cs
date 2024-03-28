using Employeedetails.Models;

namespace Employeedetails.DTO.Employeedetail
{
    public class PostEmpDetailDTOCheck
    {
      

        public string? FirstName { get; set; }

        public string? LastName { get; set; }
        public string? Gender { get; set; }

        public string? PersonalEmail { get; set; }

        public string? OfficeEmail { get; set; }

        public string MobileNumber { get; set; } = null!;

        public DateOnly DateOfBirth { get; set; }

        public DateOnly DateOfJoin { get; set; }

        public string? BloodGroup { get; set; }

        public string? AlternateContactNo { get; set; }

        public string? ContactPersonName { get; set; }

        public string? Relationship { get; set; }

        public string? MaritalStatus { get; set; }

        public int OfficeLocationId { get; set; }

        public int DepartmentId { get; set; }

        public DateOnly? LastWorkDate { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string? ModifiedBy { get; set; }

       
    }

   
}
