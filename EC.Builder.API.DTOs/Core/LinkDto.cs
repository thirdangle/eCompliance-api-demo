using System;

namespace EC.Builder.API.DTOs.Core
{
	/// <summary>
	/// Provides a list of HATEOAS links which can be used for navigating the API
	/// </summary>
    public class LinkDto
    {
		/// <summary>
		/// The URL for the link.
		/// </summary>
        public String href { get; set; }

		/// <summary>
		/// Describes the purpose of the link.
		/// </summary>
        public String rel { get; set; }

		/// <summary>
		/// The HTTP method that should be used: GET, PUT, POST, UPDATE, DELETE, etc.
		/// </summary>
        public String method { get; set; }
    }
}