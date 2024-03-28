using System;
using System.Collections.Generic;

namespace Employeedetails.Models;

public partial class Employeedetail
{
    public long Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Gender { get; set; }

    public string? PersonalEmail { get; set; }

    public string? OfficeEmail { get; set; }

    public string? MobileNumber { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public DateOnly DateOfJoin { get; set; }

    public string? BloodGroup { get; set; }

    public string? AlternateContactNo { get; set; }

    public string? ContactPersonName { get; set; }

    public string? Relationship { get; set; }

    public string? MaritalStatus { get; set; }

    public int OfficeLocationId { get; set; }

    public int DepartmentId { get; set; }

    public DateOnly? LastWorkDate { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual ICollection<Accountdetail> Accountdetails { get; set; } = new List<Accountdetail>();

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<Employeeholiday> Employeeholidays { get; set; } = new List<Employeeholiday>();

    public virtual ICollection<Employeeleavehistory> Employeeleavehistories { get; set; } = new List<Employeeleavehistory>();

    public virtual ICollection<Leaderandemployee> LeaderandemployeeEmployees { get; set; } = new List<Leaderandemployee>();

    public virtual ICollection<Leaderandemployee> LeaderandemployeeHrManagers { get; set; } = new List<Leaderandemployee>();

    public virtual ICollection<Leaderandemployee> LeaderandemployeeLeaders { get; set; } = new List<Leaderandemployee>();

    public virtual ICollection<Leavehistory> Leavehistories { get; set; } = new List<Leavehistory>();

    public virtual ICollection<Login> Logins { get; set; } = new List<Login>();

    public virtual Officelocation OfficeLocation { get; set; } = null!;

    public virtual ICollection<Productdetail> Productdetails { get; set; } = new List<Productdetail>();

    public virtual ICollection<Roledetail> Roledetails { get; set; } = new List<Roledetail>();

    public virtual ICollection<Salary> Salaries { get; set; } = new List<Salary>();
}
