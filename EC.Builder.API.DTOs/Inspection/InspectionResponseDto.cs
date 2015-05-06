using System;
using System.Collections.Generic;
using EC.Builder.API.DTOs.Core;

namespace EC.Builder.API.DTOs.Inspection
{
	public class InspectionResponseDto : InspectionSummaryDto
	{
		/// <summary>
		/// A list of sections 
		/// </summary>
	    public IEnumerable<InspectionSectionDto> Sections { get; set; }
	}

    public class InspectionSectionDto
    {
		/// <summary>
		/// The title of the section
		/// </summary>
        public string Title { get; set; }
		
		/// <summary>
		/// A list of questions
		/// </summary>
        public IEnumerable<InspectionQuestionDto> Questions { get; set; }

		/// <summary>
		/// The section's ID
		/// </summary>
        public long Id { get; set; }
    }

    public class InspectionQuestionDto
	{
		public InspectionQuestionDto()
		{
		    Files = new List<QuestionFileDto>();
		    ActionItems = new List<InspectionActionItemDto>();
		}

        public string Answer { get; set; }
        public string AllowedAnswers { get; set; }
        public string Notes { get; set; }
        public string Text { get; set; }
        public string Type { get; set; }
        public IEnumerable<QuestionFileDto> Files { get; set; }
        public IEnumerable<InspectionActionItemDto> ActionItems { get; set; }
        public long Id { get; set; }
	}

    public class QuestionFileDto
    {
        public long Id { get; set; }
        public string Extension { get; set; }
        public LinkDto Location { get; set; }
    }

    public class InspectionActionItemDto
	{
		public long Id { get; set; }
		public String Status { get; set; }
		public String ActionRequired { get; set; }
		public String DueDate { get; set; }
		public String State { get; set; }
        public IEnumerable<ActionItemAttachmentFileDto> Files { get; set; }
	}
}
