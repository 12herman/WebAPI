﻿using System;
using System.Collections.Generic;

namespace Employeedetails.Models;

public partial class Department
{
    public int Id { get; set; }

    public string? DepartmentName { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public bool? Isdeleted { get; set; }

    public virtual ICollection<Employeedetail> Employeedetails { get; set; } = new List<Employeedetail>();
}
