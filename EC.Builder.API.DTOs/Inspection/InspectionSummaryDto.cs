using EC.Builder.API.DTOs.Core;

namespace EC.Builder.API.DTOs.Inspection
{
	/// <summary>
	/// 
	/// </summary>
    public class InspectionSummaryDto : ResponseDto
    {
		/// <summary>
		/// 
		/// </summary>
        public long Id { get; set; }

		/// <summary>
		/// 
		/// </summary>
        public string Uuid { get; set; }

		/// <summary>
		/// 
		/// </summary>
        public string Title { get; set; }

		/// <summary>
		/// 
		/// </summary>
        public string SubTitle { get; set; }

		/// <summary>
		/// 
		/// </summary>
        public string Status { get; set; }

		/// <summary>
		/// 
		/// </summary>
        public string SignedOffDate { get; set; }

		/// <summary>
		/// 
		/// </summary>
        public string CreatedDate { get; set; }

		/// <summary>
		/// 
		/// </summary>
        public string Site { get; set; }

		/// <summary>
		/// 
		/// </summary>
        public string Owner { get; set; }

		/// <summary>
		/// Indicates if scoring is enabled or disabled
		/// </summary>
		public bool HasScoring { get; set; }

		/// <summary>
		/// Indicates the total score as a percentage, provided scoring is enabled
		/// </summary>
        public decimal TotalScorePercentage { get; set; }

		/// <summary>
		/// Indicates Pass/Fail based on the score
		/// </summary>
		public bool InspectionPassed { get; set; }

		/// <summary>
		/// 
		/// </summary>
        public InspectionHeaderDto Header { get; set; }
        
    }
}