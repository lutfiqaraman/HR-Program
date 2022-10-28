using HRAPI.Entities;
using HRAPI.Models;

namespace HRAPI.Repository.DepartmentRepo
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetAllDepartments();
        Task<Department?> GetDepartmentByID(int departmentId);
        Task AddDepartment(CreateDepartmentDto department);
        Task<Department?> UpdateDepartment(int departmentId, UpdateDepartmentDto department);
        bool DeleteDepartment(int id);
        Task<bool> IsDepartmentExist(int departmentId);
        Task<bool> SaveChanges();
    }
}
