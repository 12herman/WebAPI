﻿namespace Employeedetails.DTO.OfficeLocation
{
    public class PostOfficeLocationDTO
    {
        public string Officename { get; set; }
        public string? Address { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? Country { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string? ModifiedBy { get; set; }

        public bool? Isdeleted { get; set; }
    }
}