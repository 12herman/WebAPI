namespace Employeedetails.DTO.LeaveTable
{
    public class PostLeaveTableDTO
    {
        public int? SickLeave { get; set; }

        public int? CasualLeave { get; set; }

        public int? LeaveAvailed { get; set; }

        public int? Total { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string? ModifiedBy { get; set; }
    }
}
