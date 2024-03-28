namespace Employeedetails.Models
{
    public class LeaveConfirmationEmail
    {
        public string Id { get; set; }
        public long? EmployeeId { get; set; }

        public string? LeaveType { get; set; }

        public string? EmployeeName { get; set; }   

        public string? Date { get; set; }

        public string? Comments { get; set; }

        public bool? IsApproved { get; set; }

        //public string? HrEmail { get; set; }

        //public string? LeaderEmail { get; set; }
        public string? Email { get; set; }

        public double? NumberOfDays { get;set; }
    }
}
