using System;
using System.Collections.Generic;

namespace Employeedetails.Models;

public partial class Productsrepairhistory
{
    public int Id { get; set; }

    public int? ProductsDetailId { get; set; }

    public string? Comments { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual Productdetail? ProductsDetail { get; set; }
}
