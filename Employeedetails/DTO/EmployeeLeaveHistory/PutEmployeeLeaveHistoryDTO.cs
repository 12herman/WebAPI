namespace Employeedetails.DTO.EmployeeLeaveHistory
{
    public class PutEmployeeLeaveHistoryDTO
    {
        public int Id { get; set; }

        public long? EmployeeId { get; set; }

        public string? LeaveType { get; set; }

        public DateTime? Fromdate { get; set; }

        public DateTime? Todate { get; set; }

        public double? NumberOfDays { get; set; }

        public string? Comments { get; set; }

        public bool? HrIsApproved { get; set; }

        public bool? HrIsRejected { get; set; }

        public string? RejectedComments { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string? ModifiedBy { get; set; }
        public bool? LeaderIsApproved { get; set; }

        public bool? LeaderIsRejected { get; set; }
    }
}
