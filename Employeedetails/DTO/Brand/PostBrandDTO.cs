namespace Employeedetails.DTO.Brand
{
    public class PostBrandDTO
    {
        public string? Name { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string? ModifiedBy { get; set; }
        public bool? Isdeleted { get; set; }
    }
}
