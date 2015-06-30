namespace EC.Builder.API.DTOs.Employee
{
    public class UpdateEmployeeDto : AddEmployeeDto
    {
        /// <summary>
        /// The eCMS ID of the employee profile to update
        /// </summary>
        public long Id { get; set; } 
    }
}