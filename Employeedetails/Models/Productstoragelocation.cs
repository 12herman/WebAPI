using System;
using System.Collections.Generic;

namespace Employeedetails.Models;

public partial class Productstoragelocation
{
    public int Id { get; set; }

    public int? ProductDetailsId { get; set; }

    public int? OfficeLocationId { get; set; }

    public bool? IsDeleted { get; set; }

    public bool? IsAssigned { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public string? Comments { get; set; }

    public virtual Officelocation? OfficeLocation { get; set; }

    public virtual Productdetail? ProductDetails { get; set; }
}
