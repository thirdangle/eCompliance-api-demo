using EC.Builder.API.DTOs.Core;
using EC.Builder.API.DTOs.Inspection;

namespace EC.Builder.API.DTOs.Employee
{
	public class EmployeeListingRequestDto : ListingRequestDto
	{
		public EmployeeListingRequestDto()
		{
			Sort = "LastName";
		}
		
		/// <summary>
		/// Used for filtering. Only includes employees that are a partial or complete match.
		/// </summary>
		public string EmployeeId { get; set; }
		
		/// <summary>
		/// Used for filtering. Only includes employees that are a partial or complete match.
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// Used for filtering. Only includes employees that are a partial or complete match.
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		/// Used for filtering. Only includes employees that are a partial or complete match.
		/// </summary>
		public string PhoneNumber { get; set; }

		/// <summary>
		/// Used for filtering. Only includes employees that are a partial or complete match.
		/// </summary>
		public string EmailAddress { get; set; }

		/// <summary>
		///  Used for filtering. Only includes employees which have a hire date less than or equal to the date provided.
		/// </summary>
		public string HireDate { get; set; }

		/// <summary>
		///  Used for filtering. Only includes employees which have a termination date less than or equal to the date provided.
		/// </summary>
		public string TerminationDate { get; set; }

		/// <summary>
		/// Used for filtering.
		/// </summary>
		public bool? isTerminated { get; set; }

		/// <summary>
		/// Used for filtering list of employees to those that are able or unable to login.
		/// </summary>
		public bool? hasUserAccount { get; set; }
	}
}