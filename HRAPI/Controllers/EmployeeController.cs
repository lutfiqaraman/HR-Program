using HRAPI.Models.EmployeeDtos;
using HRAPI.Repository.EmployeeRepo;
using Microsoft.AspNetCore.Mvc;

namespace HRAPI.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
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

        [HttpPost]
        public async Task<ActionResult<CreateEmployeeDto>> CreateEmployee([FromBody] CreateEmployeeDto employee)
        {
            if (employee is null)
                return StatusCode(StatusCodes.Status500InternalServerError, "something is wrong");

            await employeeRepository.AddEmployee(employee);

            return Ok("Employee has been added successfully");
        }

        [HttpPut("{employeeId}")]
        public async Task<ActionResult> UpdateEmployee(int employeeId, [FromBody]  UpdateEmployeeDto employee)
        {
            if (employee is null)
                return StatusCode(StatusCodes.Status500InternalServerError, "something is wrong");

            await employeeRepository.UpdateEmployee(employeeId, employee);

            return Ok("Employee has been updated successfully");
        }

        [HttpDelete("{employeeId}")]
        public async Task<ActionResult> DeleteEmployee(int employeeId)
        {
            bool result =
                await employeeRepository.DeleteEmployee(employeeId);

            if (result)
                return Ok("Employee has been deleted");


            return StatusCode(StatusCodes.Status500InternalServerError, "something is wrong");
        }
    }
}
