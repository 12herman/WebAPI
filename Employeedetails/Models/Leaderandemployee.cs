using System;
using System.Collections.Generic;

namespace Employeedetails.Models;

public partial class Leaderandemployee
{
    public long Id { get; set; }

    public long? EmployeeId { get; set; }

    public long? LeaderId { get; set; }

    public long? HrManagerId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public bool? Isdeleted { get; set; }

    public virtual Employeedetail? Employee { get; set; }

    public virtual Employeedetail? HrManager { get; set; }

    public virtual Employeedetail? Leader { get; set; }
}
