using HRAPI.Entities;
using HRAPI.Models.DepartmentDtos;

namespace HRAPI.Repository.EmployeeRepo
{
    public interface IEmployeeRepository
    {
        Task GetAllEmployees();
        Task GetEmployeeByID(int employeeId);
    }
}
