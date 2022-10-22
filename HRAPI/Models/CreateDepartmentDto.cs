using System.ComponentModel.DataAnnotations;

namespace HRAPI.Models
{
    public class CreateDepartmentDto
    {
        [Required(ErrorMessage = "name cannot be empty, you should provide a value")]
        [MaxLength(200)]
        public string? DepartmentName { get; set; }
    }
}
