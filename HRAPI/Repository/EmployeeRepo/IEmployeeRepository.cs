using HRAPI.Entities;
using HRAPI.Models.DepartmentDtos;
using HRAPI.Models.EmployeeDtos;

namespace HRAPI.Repository.EmployeeRepo
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeDto>> GetAllEmployees();
        Task<EmployeeDto?> GetEmployeeByID(int employeeId);
        Task AddEmployee();
    }
}
