using System;
using System.Collections.Generic;

namespace Employeedetails.Models;

public partial class Employeeaccessory
{
    public int Id { get; set; }

    public int? ProductsDetailsId { get; set; }

    public long? EmployeeId { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual Employeedetail? Employee { get; set; }

    public virtual Productdetail? ProductsDetails { get; set; }
}
