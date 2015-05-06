using EC.Builder.API.DTOs.Core;

namespace EC.Builder.API.DTOs.Inspection
{
    public class ActionItemAttachmentFileDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public LinkDto Location { get; set; }
    }
}