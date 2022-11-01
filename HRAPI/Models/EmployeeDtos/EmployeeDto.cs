using HRAPI.Entities;

namespace HRAPI.Models.EmployeeDtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string? EmployeeName { get; set; }
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
