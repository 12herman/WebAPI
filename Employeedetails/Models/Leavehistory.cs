using System;
using System.Collections.Generic;

namespace Employeedetails.Models;

public partial class Leavehistory
{
    public long Id { get; set; }

    public long? EmployeeId { get; set; }

    public string? TypeOfLeave { get; set; }

    public int? NoOfDays { get; set; }

    public DateOnly? FromDate { get; set; }

    public DateOnly? ToDate { get; set; }

    public string? Comments { get; set; }

    public bool? IsApproved { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual Employeedetail? Employee { get; set; }
}
