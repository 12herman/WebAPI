namespace Employeedetails.DTO.ProductsDetail
{
    public class PostProductDetailsDTO
    {
        public int? AccessoriesId { get; set; }

        public int? BrandId { get; set; }

        public string? ProductName { get; set; }

        public string? ModelNumber { get; set; }

        public string? SerialNumber { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string? ModifiedBy { get; set; }

        public bool? IsDeleted { get; set; }

        public bool? IsRepair { get; set; }

        public bool? IsAssigned { get; set; }

        public string? Comments { get; set; }

        public int? OfficeLocationId { get; set; }

        public bool? IsStorage { get; set; }

        public long? EmployeeId { get; set; }
    }
}
