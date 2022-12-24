namespace HRAPI.Models.EmployeeDtos
{
    public class UpdateEmployeeDto
    {
        public int Id { get; set; }
        public string? EmployeeName { get; set; }
        public int DepartmentId { get; set; }
    }
}
