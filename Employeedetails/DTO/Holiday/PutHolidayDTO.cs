namespace Employeedetails.DTO.Holiday
{
    public class PutHolidayDTO
    {
        public int Id { get; set; }

        public int? OfficeLocationId { get; set; }

        public string? HolidayName { get; set; }

        public DateOnly? Date { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string? ModifiedBy { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
