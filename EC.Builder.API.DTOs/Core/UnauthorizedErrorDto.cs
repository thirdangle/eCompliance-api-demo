namespace EC.Builder.API.DTOs.Core
{
    public class UnauthorizedErrorDto :ErrorDto
    {
        public UnauthorizedErrorDto()
        {
            Message = "Unauthorized access";
            StatusCode = "401";
        }
    }
}