using System;
using System.Collections.Generic;

namespace Employeedetails.Models;

public partial class Productsquantity
{
    public int Id { get; set; }

    public long? ConsoleId { get; set; }

    public int? OfficeLocationId { get; set; }

    public string? SerialNo { get; set; }

    public bool? IsAssigned { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public bool? Isdeleted { get; set; }

    public virtual Consoles? Console { get; set; }

    public virtual Officelocation? OfficeLocation { get; set; }
}
