using HRAPI.Entities;
using HRAPI.Repository.DepartmentRepo;
using Microsoft.AspNetCore.Http;
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

        [HttpPost]
        [Route("AddDepartment")]
        public async Task<IActionResult> InsertDepartment(Department department)
        {
            Department? result =   
                await departmentRepository.InsertDepartment(department);

            if (department is null)
                return StatusCode(StatusCodes.Status500InternalServerError, "something is wrong");

            return Ok("Department has been added successfully");
        }
    }
}
