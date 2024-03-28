namespace Employeedetails.DTO.Employeedetail
{
    public class GetLocationEmpDetailDTO
    {
       public int Id { get; set; }
        public string Officename { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? Country { get; set; }
        public bool? Isdeleted { get; set; }

        //public DateTime? CreatedDate { get; set; }

        //public string? CreatedBy { get; set; }

        //public DateTime? ModifiedDate { get; set; }

        //public string? ModifiedBy { get; set; }
    }
}
