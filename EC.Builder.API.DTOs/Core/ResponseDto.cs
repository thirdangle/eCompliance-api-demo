using System.Collections.Generic;

namespace EC.Builder.API.DTOs.Core
{
    public class ResponseDto
    {
        protected ResponseDto()
        {
            Links = new List<LinkDto>();
        }

        public List<LinkDto> Links { get; set; }

        public ResponseDto AddLink(LinkDto link)
        {
            Links.Add(link);
            return this;
        }
    }
}