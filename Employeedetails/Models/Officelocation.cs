using System;
using System.Collections.Generic;

namespace Employeedetails.Models;

public partial class Officelocation
{
    public int Id { get; set; }

    public string? Officename { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Country { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public bool? Isdeleted { get; set; }

    public virtual ICollection<Employeedetail> Employeedetails { get; set; } = new List<Employeedetail>();

    public virtual ICollection<Holiday> Holidays { get; set; } = new List<Holiday>();

    public virtual ICollection<Productdetail> Productdetails { get; set; } = new List<Productdetail>();

    public virtual ICollection<Productstoragelocation> Productstoragelocations { get; set; } = new List<Productstoragelocation>();
}
