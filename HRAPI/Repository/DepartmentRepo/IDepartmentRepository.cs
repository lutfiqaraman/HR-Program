using HRAPI.Entities;

namespace HRAPI.Repository.DepartmentRepo
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetAllDepartments();
        Task<Department?> GetDepartmentByID(int departmentId);
        Task AddDepartment(Department department);
        Task<Department> UpdateDepartment(Department department);
        bool DeleteDepartment(int id);
        Task<bool> IsDepartmentExist(int departmentId);
        Task<bool> SaveChanges();
    }
}
