using System;

namespace EC.Builder.API.DTOs.Site
{
	public class SiteResponseDto : IEquatable<SiteResponseDto>
	{
		public long Id { get; set; }
		public String Name { get; set; }

		public bool Equals(SiteResponseDto otherSiteDto)
		{
			if (otherSiteDto == null)
			{
				return false;
			}
			if (otherSiteDto.Id == this.Id)
			{
				return true;
			}

			return false;
		}

		public override int GetHashCode()
		{
			return this.Id.GetHashCode();
		}
	}
}
