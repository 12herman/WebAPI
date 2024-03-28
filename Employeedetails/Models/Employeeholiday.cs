using System;
using System.Collections.Generic;

namespace Employeedetails.Models;

public partial class Employeeholiday
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

    public bool? Isdeleted { get; set; }

    public virtual Employeedetail? Employee { get; set; }
}
