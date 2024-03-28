using System;
using System.Collections.Generic;

namespace Employeedetails.Models;

public partial class Roledetail
{
    public int Id { get; set; }

    public int? RoleId { get; set; }

    public long? EmployeeId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public bool? Isdeleted { get; set; }

    public virtual Employeedetail? Employee { get; set; }

    public virtual Role? Role { get; set; }
}
