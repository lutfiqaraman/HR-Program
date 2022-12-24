using System.ComponentModel.DataAnnotations;

namespace HRAPI.Models.DepartmentDtos
{
    public class UpdateDepartmentDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "name cannot be empty, you should provide a value")]
        [MaxLength(200)]
        public string? DepartmentName { get; set; }
    }
}
