using HRAPI.Models;

namespace HRAPI.Repository.DepartmentRepo
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetAllDepartments();
        Task<Department> GetDepartmentByID(int id);
        Task<Department> InsertDepartment(Department department);
        Task<Department> UpdateDepartment(Department department);
        bool DeleteDepartment(int id);
    }
}
