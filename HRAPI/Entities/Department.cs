using HRAPI.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRAPI.Entities
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
