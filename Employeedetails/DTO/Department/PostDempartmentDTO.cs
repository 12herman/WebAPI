﻿namespace Employeedetails.DTO.Department
{
    public class PostDempartmentDTO
    {
        public string? DepartmentName { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string? ModifiedBy { get; set; }
        public bool? Isdeleted { get; set; }
    }
}
