using System.Collections.Generic;

namespace EC.Builder.API.DTOs.Employee
{
    public class EmployeeImportResponseDto
    {
        public EmployeeImportResponseDto()
        {
            Errors = new List<EmployeeToImportErrorDto>();
        }

        public IEnumerable<EmployeeToImportErrorDto> Errors { get; set; }
        public EmployeeImportSummaryDto ImportSummary { get; set; }
    }
}