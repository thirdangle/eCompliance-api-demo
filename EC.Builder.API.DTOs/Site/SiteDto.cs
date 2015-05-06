using System;

namespace EC.Builder.API.DTOs.Site
{
	public class SiteDto : IEquatable<SiteDto>
	{
		public long Id { get; set; }
		public String Name { get; set; }

		public bool Equals(SiteDto otherSiteDto)
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
			int hashId = Id == null ? 0 : Id.GetHashCode();

			return hashId;
		}
	}
}
