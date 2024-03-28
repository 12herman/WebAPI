namespace Employeedetails.DTO.Employeedetail
{
    public class GetRoleDetailsEmpDetailDTO
    {
        public int Id { get; set; }

        public int? RoleId { get; set; }

        public string RoleName { get; set; }

        public bool? Isdeleted { get; set; }
        public long? EmployeeId { get; set; }

        //public DateTime? CreatedDate { get; set; }

        //public string? CreatedBy { get; set; }

        //public DateTime? ModifiedDate { get; set; }

        //public string? ModifiedBy { get; set; }
    }
}
