using System.Collections.Generic;

namespace EC.Builder.API.DTOs.Employee
{
    public class AddEmployeeDto
    {
        /// <summary>
        /// Organization identifier for employee (eg "j.smith1")
        /// </summary>
        public string EmployeeId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        public string HireDate { get; set; }
        /// <summary>
        /// Date of termination. Leave blank for current employees.
        /// If this employee has a user account, they will no longer be
        /// able to log in after this date.
        /// </summary>
        public string TerminationDate { get; set; }

        public string Notes { get; set; }
        /// <summary>
        /// All site memberships. Any current memberships that are
        /// not included here will be removed.
        /// </summary>
        public IList<EmployeeSiteDto> Sites { get; set; }

        public bool IsSingleSignOnUser { get; set; }
    }

    public class EmployeeSiteDto
    {
        public long SiteId { get; set; }
        public IList<string> JobProfiles { get; set; }
        public string Permission { get; set; }

        public EmployeeSiteDto()
        {
            JobProfiles = new List<string>();
        }
    }
}