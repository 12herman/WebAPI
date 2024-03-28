using System;
using System.Collections.Generic;

namespace Employeedetails.Models;

public partial class Consoles
{
    public long Id { get; set; }

    public int? AccessoriesId { get; set; }

    public int? BrandId { get; set; }

    public string? ModelNumber { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }
    public string ? ProductName { get; set; }
    public virtual Accessory? Accessories { get; set; }

    public  Brand? Brand { get; set; }
    public bool? Isdeleted { get; set; }

    public  List<Employeeaccessory> Employeeaccessories { get; set; } = new List<Employeeaccessory>();

    public  List<Productsquantity> Productsquantities { get; set; } = new List<Productsquantity>();
}
