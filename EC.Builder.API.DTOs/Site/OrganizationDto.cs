using System;
using System.Collections.Generic;

namespace EC.Builder.API.DTOs.Site
{
	public class OrganizationDto
	{
		public OrganizationDto()
		{
			Sites = new List<SiteResponseDto>();
		}

		public String Name { get; set; }
		public List<SiteResponseDto> Sites { get; set; } 
	}
}
