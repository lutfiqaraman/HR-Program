using HRAPI.Entities;
using HRAPI.Models.DepartmentDtos;
using HRAPI.Repository.DepartmentRepo;
using Microsoft.AspNetCore.Mvc;

namespace HRAPI.Controllers
{
    [Route("api/department")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository departmentRepository;

        public DepartmentController(IDepartmentRepository DepartmentRepository)
        {
            departmentRepository =
                DepartmentRepository ?? throw new ArgumentNullException(nameof(DepartmentRepository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentDto>>> GetAllDepartments()
        {
            IEnumerable<DepartmentDto> departments = 
                await departmentRepository.GetAllDepartments();

            return Ok(departments);
        }

        [HttpPost]
        public async Task<ActionResult<CreateDepartmentDto>> CreateDepartment([FromBody] CreateDepartmentDto department)
        {
            if (department is null)
                return StatusCode(StatusCodes.Status500InternalServerError, "something is wrong");

            await departmentRepository.AddDepartment(department);

            return Ok("Department has been added successfully");
        }

        [HttpPut("{departmentid}")]
        public async Task<ActionResult> UpdateDepartment(int departmentId, UpdateDepartmentDto department)
        {
            if (department is null)
                return StatusCode(StatusCodes.Status500InternalServerError, "something is wrong");

            await departmentRepository.UpdateDepartment(departmentId, department);

            return Ok("Department has been updated successfully");
        }

        [HttpDelete("{departmentid}")]
        public async Task<ActionResult> DeleteDepartment(int departmentId)
        {
            bool result =  
                await departmentRepository.DeleteDepartment(departmentId);

            if (result)
                return Ok("Department has been deleted");
            
                
            return StatusCode(StatusCodes.Status500InternalServerError, "something is wrong");
        }
    }
}
