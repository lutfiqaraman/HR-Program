using HRAPI.Entities;
using HRAPI.Models.DepartmentDtos;

namespace HRAPI.Repository.DepartmentRepo
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<DepartmentDto>> GetAllDepartments();
        Task<Department?> GetDepartmentByID(int departmentId);
        Task AddDepartment(CreateDepartmentDto department);
        Task<Department?> UpdateDepartment(int departmentId, UpdateDepartmentDto department);
        Task<bool> DeleteDepartment(int departmentId);
        Task<bool> IsDepartmentExist(int departmentId);
    }
}
