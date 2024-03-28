using System;
using System.Collections.Generic;

namespace Employeedetails.Models;

public partial class Salary
{
    public int Id { get; set; }

    public long? EmployeeId { get; set; }

    public int? Ctc { get; set; }

    public int? GrossSalary { get; set; }

    public int? NetSalary { get; set; }

    public DateTime? SalaryDate { get; set; }

    public bool? IsRevised { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual Employeedetail? Employee { get; set; }
}
