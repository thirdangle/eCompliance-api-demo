using EC.Builder.API.DTOs.Core;

namespace EC.Builder.API.DTOs.Employee
{
	public class EmployeeDto : ResponseDto
	{
		public string EmployeeId { get; set; }

		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PhoneNumber { get; set; }
		public string EmailAddress { get; set; }

		public string HireDate { get; set; }
		public string TerminationDate { get; set; }

		public string Notes { get; set; }

		public bool isTerminated { get; set; }
		public bool hasUserAccount { get; set; }
	}
}