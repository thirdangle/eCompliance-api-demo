using System;
using EC.Builder.API.DTOs.Core;

namespace EC.Builder.API.DTOs.Inspection
{
	public class InspectionListingRequestDto : ListingRequestDto
	{
	    public InspectionListingRequestDto()
	    {
	        Sort = "title";
	    }

		/// <summary>
		/// Indicates whether or not the item has been signed off/locked.
		/// </summary>
	    public bool? IsSignedOff { get; set; }

		/// <summary>
		/// Used for filtering. Only includes items which have a signed off date greater than or equal to the date provided.
		/// </summary>
		public String SignedOffStartDate { get; set; }

		/// <summary>
		/// Used for filtering. Only includes items which have a signed off date less than or equal to the date provided.
		/// </summary>
		public String SignedOffEndDate { get; set; }

		/// <summary>
		/// Used for searching for a partial or complete match to the item's title. You can specify this column for sorting.
		/// </summary>
	    public string Title { get; set; }
	}

    public abstract class ListingRequestDto
    {
        protected ListingRequestDto()
        {
            SortDirection = SortDto.Ascending;
        }

		/// <summary>
        /// Sort by the specified URI parameter. Sort can be applied to title and IsSignedOff fields. i.e. url?sort=title or url?sort=IsSignedOff. The default sort direction is ascending.
		/// </summary>
        public string Sort { get; set; }

		/// <summary>
		/// How to sort the responses. Use the values of "Asc" for ascending order, or "Desc" for descending order.
		/// </summary>
        public string SortDirection { get; set; }

        public bool IsAscending()
        {
            return SortDto.Ascending.Equals(SortDirection.ToLower());
        }
    }
}
