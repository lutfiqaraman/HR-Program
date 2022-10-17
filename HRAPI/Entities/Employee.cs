using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRAPI.Entities
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string? EmployeeName { get; set; }
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
