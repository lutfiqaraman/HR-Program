using HRAPI.Entities;
using HRAPI.Models.EmployeeDtos;

namespace HRAPI.Repository.EmployeeRepo
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeDto>> GetAllEmployees();
        Task<EmployeeDto?> GetEmployeeByID(int employeeId);
        Task AddEmployee(CreateEmployeeDto employee);
        Task<UpdateEmployeeDto?> UpdateEmployee(int employeeId, UpdateEmployeeDto employee);
        Task<bool> DeleteEmployee(int employeeId);
    }
}
