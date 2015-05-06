namespace EC.Builder.API.DTOs.Core
{
	/// <summary>
	/// Provides information for results that are paged.
	/// </summary>
    public class PagingInfoDto
    {
		/// <summary>
		/// Indicates what page number the results are from. Base index is 1.
		/// </summary>
        public int PageNumber { get; set; }

		/// <summary>
		/// The total number of pages for the result set. Base index is 1.
		/// </summary>
        public int PageCount { get; set; }

		/// <summary>
		/// The page size for the result set. Base index is 1.
		/// </summary>
        public int PageSize { get; set; }

		/// <summary>
		/// The total number of items accross all pages. Base index is 1.
		/// </summary>
        public int TotalNumberOfItems { get; set; }
    }
}