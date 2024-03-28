using System;
using System.Collections.Generic;

namespace Employeedetails.Models;

public partial class Accountdetail
{
    public long Id { get; set; }

    public long? EmployeeId { get; set; }

    public string? BankName { get; set; }

    public string? BranchName { get; set; }

    public string? BankLocation { get; set; }

    public long? AccountNumber { get; set; }

    public string? Ifsc { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public bool? Isdeleted { get; set; }

    public virtual Employeedetail? Employee { get; set; }
}
