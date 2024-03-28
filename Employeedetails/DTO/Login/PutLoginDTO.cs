namespace Employeedetails.DTO.Login
{
    public class PutLoginDTO
    {
        public long Id { get; set; }

        public long? EmployeeId { get; set; }

        public string? UserName { get; set; }

        public string? Password { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string? ModifiedBy { get; set; }
        public string? Otp { get; set; }
    }
}
