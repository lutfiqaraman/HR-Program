using HRAPI.Models.DepartmentDtos;
using HRAPI.Models.EmployeeDtos;
using HRAPI.Repository.DepartmentRepo;
using HRAPI.Repository.EmployeeRepo;
using Microsoft.AspNetCore.Mvc;

namespace HRAPI.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeController(IEmployeeRepository EmployeeRepository)
        {
            employeeRepository = 
                EmployeeRepository ?? throw new ArgumentNullException(nameof(EmployeeRepository));

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetAllEmployees()
        {
            IEnumerable<EmployeeDto> employees =
                await employeeRepository.GetAllEmployees();

            return Ok(employees);
        }

        [HttpGet("{employeeId}")]
        public async Task<ActionResult<EmployeeDto>> GetEmployeeById(int employeeId)
        {
            EmployeeDto? employee =
                await employeeRepository.GetEmployeeByID(employeeId);

            return Ok(employee);
        }

    }
}
