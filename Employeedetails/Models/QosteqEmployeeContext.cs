using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Employeedetails.Models;

public partial class QosteqEmployeeContext : DbContext
{
    public QosteqEmployeeContext()
    {
    }

    public QosteqEmployeeContext(DbContextOptions<QosteqEmployeeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Accessory> Accessories { get; set; }

    public virtual DbSet<Accountdetail> Accountdetails { get; set; }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employeedetail> Employeedetails { get; set; }

    public virtual DbSet<Employeeholiday> Employeeholidays { get; set; }

    public virtual DbSet<Employeeleavehistory> Employeeleavehistories { get; set; }

    public virtual DbSet<Holiday> Holidays { get; set; }

    public virtual DbSet<Leaderandemployee> Leaderandemployees { get; set; }

    public virtual DbSet<Leavehistory> Leavehistories { get; set; }

    public virtual DbSet<Leavetable> Leavetables { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<Officelocation> Officelocations { get; set; }

    public virtual DbSet<Productdetail> Productdetails { get; set; }

    public virtual DbSet<Productsrepairhistory> Productsrepairhistories { get; set; }

    public virtual DbSet<Productstoragelocation> Productstoragelocations { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Roledetail> Roledetails { get; set; }

    public virtual DbSet<Salary> Salaries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=QosteqEmployee;user=root;password=1234", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.35-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Accessory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("accessories");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy).HasMaxLength(60);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValueSql("'0'")
                .HasColumnName("isdeleted");
            entity.Property(e => e.ModifiedBy).HasMaxLength(60);
            entity.Property(e => e.ModifiedDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Accountdetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("accountdetails");

            entity.HasIndex(e => e.EmployeeId, "FK_AccountDetailEmployeeId");

            entity.Property(e => e.BankLocation).HasMaxLength(80);
            entity.Property(e => e.BankName).HasMaxLength(80);
            entity.Property(e => e.BranchName).HasMaxLength(80);
            entity.Property(e => e.CreatedBy).HasMaxLength(60);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.Ifsc).HasMaxLength(255);
            entity.Property(e => e.Isdeleted)
                .HasDefaultValueSql("'0'")
                .HasColumnName("isdeleted");
            entity.Property(e => e.ModifiedBy).HasMaxLength(60);
            entity.Property(e => e.ModifiedDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Employee).WithMany(p => p.Accountdetails)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_AccountDetailEmployeeId");
        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("address");

            entity.HasIndex(e => e.EmployeeId, "Fk_AddressId");

            entity.Property(e => e.Address1)
                .HasMaxLength(255)
                .HasColumnName("Address");
            entity.Property(e => e.City).HasMaxLength(60);
            entity.Property(e => e.Country).HasMaxLength(60);
            entity.Property(e => e.CreatedBy).HasMaxLength(60);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValueSql("'0'")
                .HasColumnName("isdeleted");
            entity.Property(e => e.ModifiedBy).HasMaxLength(60);
            entity.Property(e => e.ModifiedDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.State).HasMaxLength(60);
            entity.Property(e => e.Type).HasColumnName("type");

            entity.HasOne(d => d.Employee).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("Fk_AddressId");
        });

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("brand");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy).HasMaxLength(60);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValueSql("'0'")
                .HasColumnName("isdeleted");
            entity.Property(e => e.ModifiedBy).HasMaxLength(60);
            entity.Property(e => e.ModifiedDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("department");

            entity.Property(e => e.CreatedBy).HasMaxLength(60);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.DepartmentName).HasMaxLength(255);
            entity.Property(e => e.Isdeleted)
                .HasDefaultValueSql("'0'")
                .HasColumnName("isdeleted");
            entity.Property(e => e.ModifiedBy).HasMaxLength(60);
            entity.Property(e => e.ModifiedDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Employeedetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("employeedetails");

            entity.HasIndex(e => e.DepartmentId, "FK_DepartmentId");

            entity.HasIndex(e => e.OfficeLocationId, "FK_OfficeLocationId");

            entity.Property(e => e.AlternateContactNo).HasMaxLength(255);
            entity.Property(e => e.BloodGroup).HasMaxLength(255);
            entity.Property(e => e.ContactPersonName).HasMaxLength(255);
            entity.Property(e => e.CreatedBy).HasMaxLength(60);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.FirstName).HasMaxLength(60);
            entity.Property(e => e.Gender).HasMaxLength(50);
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("'0'");
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.MaritalStatus).HasMaxLength(255);
            entity.Property(e => e.MobileNumber).HasMaxLength(255);
            entity.Property(e => e.ModifiedBy).HasMaxLength(60);
            entity.Property(e => e.ModifiedDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.OfficeEmail).HasMaxLength(255);
            entity.Property(e => e.PersonalEmail).HasMaxLength(255);
            entity.Property(e => e.Relationship).HasMaxLength(255);

            entity.HasOne(d => d.Department).WithMany(p => p.Employeedetails)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DepartmentId");

            entity.HasOne(d => d.OfficeLocation).WithMany(p => p.Employeedetails)
                .HasForeignKey(d => d.OfficeLocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OfficeLocationId");
        });

        modelBuilder.Entity<Employeeholiday>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("employeeholiday");

            entity.HasIndex(e => e.EmployeeId, "FK_EmployeeHoliDay");

            entity.Property(e => e.CreatedBy).HasMaxLength(60);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValueSql("'0'")
                .HasColumnName("isdeleted");
            entity.Property(e => e.ModifiedBy).HasMaxLength(60);
            entity.Property(e => e.ModifiedDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Employee).WithMany(p => p.Employeeholidays)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_EmployeeHoliDay");
        });

        modelBuilder.Entity<Employeeleavehistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("employeeleavehistory");

            entity.HasIndex(e => e.EmployeeId, "FK_EmployeeLeaveHistory");

            entity.Property(e => e.Comments).HasColumnType("text");
            entity.Property(e => e.CreatedBy).HasMaxLength(60);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.Fromdate).HasColumnType("datetime");
            entity.Property(e => e.HrIsApproved).HasDefaultValueSql("'0'");
            entity.Property(e => e.HrIsRejected).HasDefaultValueSql("'0'");
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("'0'");
            entity.Property(e => e.LeaderIsApproved).HasDefaultValueSql("'0'");
            entity.Property(e => e.LeaderIsRejected).HasDefaultValueSql("'0'");
            entity.Property(e => e.LeaveType).HasMaxLength(255);
            entity.Property(e => e.ModifiedBy).HasMaxLength(60);
            entity.Property(e => e.ModifiedDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.RejectedComments).HasColumnType("text");
            entity.Property(e => e.Todate).HasColumnType("datetime");

            entity.HasOne(d => d.Employee).WithMany(p => p.Employeeleavehistories)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_EmployeeLeaveHistory");
        });

        modelBuilder.Entity<Holiday>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("holiday");

            entity.HasIndex(e => e.OfficeLocationId, "FK_Holiday");

            entity.Property(e => e.CreatedBy).HasMaxLength(60);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.HolidayName).HasMaxLength(255);
            entity.Property(e => e.Isdeleted)
                .HasDefaultValueSql("'0'")
                .HasColumnName("isdeleted");
            entity.Property(e => e.ModifiedBy).HasMaxLength(60);
            entity.Property(e => e.ModifiedDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");

            entity.HasOne(d => d.OfficeLocation).WithMany(p => p.Holidays)
                .HasForeignKey(d => d.OfficeLocationId)
                .HasConstraintName("FK_Holiday");
        });

        modelBuilder.Entity<Leaderandemployee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("leaderandemployee");

            entity.HasIndex(e => e.EmployeeId, "FK_LeaderEmployeeId");

            entity.HasIndex(e => e.HrManagerId, "FK_LeaderHrManagerId");

            entity.HasIndex(e => e.LeaderId, "FK_LeaderLeaderId");

            entity.Property(e => e.CreatedBy).HasMaxLength(60);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.HrManagerId).HasColumnName("HrManagerID");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValueSql("'0'")
                .HasColumnName("isdeleted");
            entity.Property(e => e.ModifiedBy).HasMaxLength(60);
            entity.Property(e => e.ModifiedDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Employee).WithMany(p => p.LeaderandemployeeEmployees)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_LeaderEmployeeId");

            entity.HasOne(d => d.HrManager).WithMany(p => p.LeaderandemployeeHrManagers)
                .HasForeignKey(d => d.HrManagerId)
                .HasConstraintName("FK_LeaderHrManagerId");

            entity.HasOne(d => d.Leader).WithMany(p => p.LeaderandemployeeLeaders)
                .HasForeignKey(d => d.LeaderId)
                .HasConstraintName("FK_LeaderLeaderId");
        });

        modelBuilder.Entity<Leavehistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("leavehistory");

            entity.HasIndex(e => e.EmployeeId, "FK_EmployeeId");

            entity.Property(e => e.Comments).HasColumnType("text");
            entity.Property(e => e.CreatedBy).HasMaxLength(60);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.IsApproved).HasDefaultValueSql("'0'");
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("'0'");
            entity.Property(e => e.ModifiedBy).HasMaxLength(60);
            entity.Property(e => e.ModifiedDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.TypeOfLeave).HasMaxLength(255);

            entity.HasOne(d => d.Employee).WithMany(p => p.Leavehistories)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_EmployeeId");
        });

        modelBuilder.Entity<Leavetable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("leavetable");

            entity.Property(e => e.CreatedBy).HasMaxLength(60);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy).HasMaxLength(60);
            entity.Property(e => e.ModifiedDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("login");

            entity.HasIndex(e => e.EmployeeId, "FK_Login");

            entity.Property(e => e.CreatedBy).HasMaxLength(60);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("'0'");
            entity.Property(e => e.ModifiedBy).HasMaxLength(60);
            entity.Property(e => e.ModifiedDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.Otp).HasMaxLength(255);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.UserName).HasMaxLength(255);

            entity.HasOne(d => d.Employee).WithMany(p => p.Logins)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_Login");
        });

        modelBuilder.Entity<Officelocation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("officelocation");

            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.City).HasMaxLength(60);
            entity.Property(e => e.Country).HasMaxLength(60);
            entity.Property(e => e.CreatedBy).HasMaxLength(60);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValueSql("'0'")
                .HasColumnName("isdeleted");
            entity.Property(e => e.ModifiedBy).HasMaxLength(60);
            entity.Property(e => e.ModifiedDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.Officename)
                .HasMaxLength(255)
                .HasColumnName("officename");
            entity.Property(e => e.State).HasMaxLength(60);
        });

        modelBuilder.Entity<Productdetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("productdetails");

            entity.HasIndex(e => e.EmployeeId, "FK_EmployeeKey");

            entity.HasIndex(e => e.AccessoriesId, "FK_ProductDetails_Accessories");

            entity.HasIndex(e => e.BrandId, "FK_ProductDetails_Brand");

            entity.HasIndex(e => e.OfficeLocationId, "OfficeLocationId");

            entity.Property(e => e.Comments).HasColumnType("text");
            entity.Property(e => e.CreatedBy).HasMaxLength(60);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("'0'");
            entity.Property(e => e.ModelNumber).HasMaxLength(255);
            entity.Property(e => e.ModifiedBy).HasMaxLength(60);
            entity.Property(e => e.ModifiedDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.ProductName).HasMaxLength(255);
            entity.Property(e => e.SerialNumber).HasMaxLength(255);

            entity.HasOne(d => d.Accessories).WithMany(p => p.Productdetails)
                .HasForeignKey(d => d.AccessoriesId)
                .HasConstraintName("FK_ProductDetails_Accessories");

            entity.HasOne(d => d.Brand).WithMany(p => p.Productdetails)
                .HasForeignKey(d => d.BrandId)
                .HasConstraintName("FK_ProductDetails_Brand");

            entity.HasOne(d => d.Employee).WithMany(p => p.Productdetails)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_EmployeeKey");

            entity.HasOne(d => d.OfficeLocation).WithMany(p => p.Productdetails)
                .HasForeignKey(d => d.OfficeLocationId)
                .HasConstraintName("productdetails_ibfk_1");
        });

        modelBuilder.Entity<Productsrepairhistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("productsrepairhistory");

            entity.HasIndex(e => e.ProductsDetailId, "FK_ProductsRepairHistory");

            entity.Property(e => e.Comments).HasColumnType("text");
            entity.Property(e => e.CreatedBy).HasMaxLength(60);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("'0'");
            entity.Property(e => e.ModifiedBy).HasMaxLength(60);
            entity.Property(e => e.ModifiedDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");

            entity.HasOne(d => d.ProductsDetail).WithMany(p => p.Productsrepairhistories)
                .HasForeignKey(d => d.ProductsDetailId)
                .HasConstraintName("FK_ProductsRepairHistory");
        });

        modelBuilder.Entity<Productstoragelocation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("productstoragelocation");

            entity.HasIndex(e => e.ProductDetailsId, "FK_ProductDetailsId");

            entity.HasIndex(e => e.OfficeLocationId, "FK_officeLocationsId_ProductDetails");

            entity.Property(e => e.Comments).HasMaxLength(255);
            entity.Property(e => e.CreatedBy).HasMaxLength(60);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.IsAssigned).HasDefaultValueSql("'0'");
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("'0'");
            entity.Property(e => e.ModifiedBy).HasMaxLength(60);
            entity.Property(e => e.ModifiedDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");

            entity.HasOne(d => d.OfficeLocation).WithMany(p => p.Productstoragelocations)
                .HasForeignKey(d => d.OfficeLocationId)
                .HasConstraintName("FK_officeLocationsId_ProductDetails");

            entity.HasOne(d => d.ProductDetails).WithMany(p => p.Productstoragelocations)
                .HasForeignKey(d => d.ProductDetailsId)
                .HasConstraintName("FK_ProductDetailsId");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("roles");

            entity.Property(e => e.CreatedBy).HasMaxLength(60);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValueSql("'0'")
                .HasColumnName("isdeleted");
            entity.Property(e => e.ModifiedBy).HasMaxLength(60);
            entity.Property(e => e.ModifiedDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.RollName).HasMaxLength(255);
        });

        modelBuilder.Entity<Roledetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("roledetails");

            entity.HasIndex(e => e.RoleId, "FK_RoleId");

            entity.HasIndex(e => e.EmployeeId, "Fk_RoleEmployeeId");

            entity.Property(e => e.CreatedBy).HasMaxLength(60);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValueSql("'0'")
                .HasColumnName("isdeleted");
            entity.Property(e => e.ModifiedBy).HasMaxLength(60);
            entity.Property(e => e.ModifiedDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Employee).WithMany(p => p.Roledetails)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("Fk_RoleEmployeeId");

            entity.HasOne(d => d.Role).WithMany(p => p.Roledetails)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_RoleId");
        });

        modelBuilder.Entity<Salary>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("salary");

            entity.HasIndex(e => e.EmployeeId, "FK_EmployeesID");

            entity.Property(e => e.CreatedBy).HasMaxLength(60);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("'0'");
            entity.Property(e => e.IsRevised).HasDefaultValueSql("'1'");
            entity.Property(e => e.ModifiedBy).HasMaxLength(60);
            entity.Property(e => e.ModifiedDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.SalaryDate).HasColumnType("datetime");

            entity.HasOne(d => d.Employee).WithMany(p => p.Salaries)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_EmployeesID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
