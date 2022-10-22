using AutoMapper;
using HRAPI.Entities;
using HRAPI.Models;
using HRAPI.Repository.DepartmentRepo;
using Microsoft.AspNetCore.Mvc;

namespace HRAPI.Controllers
{
    [Route("api/department")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository departmentRepository;
        private readonly IMapper mapper;

        public DepartmentController(IDepartmentRepository DepartmentRepository, IMapper Mapper)
        {
            departmentRepository = 
                DepartmentRepository ?? throw new ArgumentNullException(nameof(DepartmentRepository));

            mapper = 
                Mapper ?? throw new ArgumentNullException(nameof(Mapper));
        }

        [HttpPost]
        public async Task<ActionResult<CreateDepartmentDto>> CreateDepartment([FromBody] CreateDepartmentDto department)
        {
            if (department is null)
                return StatusCode(StatusCodes.Status500InternalServerError, "something is wrong");

            Department? mappedDepartment =   
                mapper.Map<Department>(department);

            await departmentRepository.AddDepartment(mappedDepartment);

            await departmentRepository.SaveChanges();

            return Ok("Department has been added successfully");
        }
    }
}
