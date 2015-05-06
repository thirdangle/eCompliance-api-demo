using System.Collections.Generic;

namespace EC.Builder.API.DTOs.Core
{
    public class ListingResponseDto<t> :ResponseDto
    {
		/// <summary>
		/// 
		/// </summary>
        public PagingInfoDto PagingInfo { get; set; }

		/// <summary>
		/// 
		/// </summary>
        public IEnumerable<t> Values { get; set; } 
    }
}