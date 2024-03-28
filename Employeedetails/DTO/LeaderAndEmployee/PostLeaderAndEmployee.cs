namespace Employeedetails.DTO.LeaderAndEmployee
{
    public class PostLeaderAndEmployee
    {
    //public long Id { get; set; }

    public long? EmployeeId { get; set; }

    public long? LeaderId { get; set; }

    public long? HrManagerId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }
     public bool? IsDeleted { get; set; }
    }
}
