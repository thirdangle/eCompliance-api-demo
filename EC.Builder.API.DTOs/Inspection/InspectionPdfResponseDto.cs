using System;

namespace EC.Builder.API.DTOs.Inspection
{
	public class InspectionPdfResponseDto
	{
		public String FileName { get; set; }
		public Byte[] PdfData { get; set; }
	}
}
