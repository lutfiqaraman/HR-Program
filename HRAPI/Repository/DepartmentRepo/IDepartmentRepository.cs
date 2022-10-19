using HRAPI.Entities;

namespace HRAPI.Repository.DepartmentRepo
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetAllDepartments();
        Task<Department> GetDepartmentByID(int id);
        Task<Department> InsertDepartment(Department department);
        Task<Department> UpdateDepartment(Department department);
        bool DeleteDepartment(int id);
        Task<bool> IsDepartmentExist(int departmentId);
        Task<bool> SaveChanges();
    }
}
