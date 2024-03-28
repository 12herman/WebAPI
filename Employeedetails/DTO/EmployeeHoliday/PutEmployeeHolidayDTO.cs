namespace Employeedetails.DTO.EmployeeHoliday
{
    public class PutEmployeeHolidayDTO
    {
        public int Id { get; set; }

        public long? EmployeeId { get; set; }

        public double? SickLeave { get; set; }

        public double? CasualLeave { get; set; }

        public double? Total { get; set; }

        public double? LeaveAvailed { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string? ModifiedBy { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
