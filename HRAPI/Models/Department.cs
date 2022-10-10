using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRAPI.Models
{
    [Table("Department")]
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string? DepartmentName { get; set; }
        public ICollection<Employee>? Employees { get; set; }
    }
}
