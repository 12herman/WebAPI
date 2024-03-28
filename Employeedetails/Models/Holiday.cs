using System;
using System.Collections.Generic;

namespace Employeedetails.Models;

public partial class Holiday
{
    public int Id { get; set; }

    public int? OfficeLocationId { get; set; }

    public string? HolidayName { get; set; }

    public DateOnly? Date { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public bool? Isdeleted { get; set; }

    public virtual Officelocation? OfficeLocation { get; set; }
}
