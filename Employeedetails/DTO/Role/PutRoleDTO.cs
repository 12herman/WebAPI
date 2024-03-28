namespace Employeedetails.DTO.Role
{
    public class PutRoleDTO
    {
        public int Id { get; set; }

        public string? RollName { get; set; }
        public bool? Isdeleted { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string? ModifiedBy { get; set; }
    }
}
