using System;
using System.Collections.Generic;

namespace Employeedetails.Models;

public partial class Productdetail
{
    public int Id { get; set; }

    public int? AccessoriesId { get; set; }

    public int? BrandId { get; set; }

    public string? ProductName { get; set; }

    public string? ModelNumber { get; set; }

    public string? SerialNumber { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public bool? IsRepair { get; set; }

    public bool? IsAssigned { get; set; }

    public string? Comments { get; set; }

    public int? OfficeLocationId { get; set; }

    public bool? IsStorage { get; set; }

    public long? EmployeeId { get; set; }

    public virtual Accessory? Accessories { get; set; }

    public virtual Brand? Brand { get; set; }

    public virtual Employeedetail? Employee { get; set; }

    public virtual Officelocation? OfficeLocation { get; set; }

    public virtual ICollection<Productsrepairhistory> Productsrepairhistories { get; set; } = new List<Productsrepairhistory>();

    public virtual ICollection<Productstoragelocation> Productstoragelocations { get; set; } = new List<Productstoragelocation>();
}
