using Employeedetails.Models;

namespace Employeedetails.DTO.Employeedetail
{
    public class GetEmpAccountDetailsDTO
    {
        public long Id { get; set; }

        public long? EmployeeId { get; set; }

        public string? BankName { get; set; }

        public string? BranchName { get; set; }

        public string? BankLocation { get; set; }

        public long? AccountNumber { get; set; }

        public string? Ifsc { get; set; }
        public bool? Isdeleted { get; set; }

        //public DateTime? CreatedDate { get; set; }

        //public string? CreatedBy { get; set; }

        //public DateTime? ModifiedDate { get; set; }
        //public string? ModifiedBy { get; set; }

    }
}
