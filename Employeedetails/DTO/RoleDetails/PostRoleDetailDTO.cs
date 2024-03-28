namespace Employeedetails.DTO.RoleDetails
{
    public class PostRoleDetailDTO
    {

        public int? RoleId { get; set; }

        public long? EmployeeId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string? ModifiedBy { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
