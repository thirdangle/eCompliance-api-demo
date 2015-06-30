using System.Collections.Generic;

namespace EC.Builder.API.DTOs.Employee
{
    public class EmployeeToImportRequestDto
    {
        public EmployeeToImportRequestDto()
        {
            Sites = new List<EmployeeToImportSite>();
        }

        public string EmployeeId { get; set; }
		public string FirstName { get; set; }
        public string LastName { get; set; }
		public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string HireDate { get; set; }
        public string TerminationDate { get; set; }
        public List<EmployeeToImportSite> Sites { get; set; }
        public bool IsSingleSignOnUser { get; set; }
    }

    public class EmployeeToImportSite
    {
        public string Name { get; set; }
        public List<string> JobProfiles { get; set;}
        public string Permission { get; set; }

        public EmployeeToImportSite()
        {
            JobProfiles = new List<string>();
        }
    }


    public class EmployeeToImportErrorDto : EmployeeToImportRequestDto
    {
        public string ErrorMessage { get; set; }
    }
}