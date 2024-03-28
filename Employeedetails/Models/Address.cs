using System;
using System.Collections.Generic;

namespace Employeedetails.Models;

public partial class Address
{
    public long Id { get; set; }

    public long? EmployeeId { get; set; }

    public string? Address1 { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Country { get; set; }

    public long? PostalCode { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public bool? Isdeleted { get; set; }

    public int? Type { get; set; }

    public virtual Employeedetail? Employee { get; set; }
}
