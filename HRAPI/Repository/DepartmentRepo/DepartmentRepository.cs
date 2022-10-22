using HRAPI.DbContexts;
using HRAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace HRAPI.Repository.DepartmentRepo
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly HRContext _context;

        public DepartmentRepository(HRContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public bool DeleteDepartment(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Department>> GetAllDepartments()
        {
            throw new NotImplementedException();
        }

        public Task<Department> GetDepartmentByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task AddDepartment(Department department)
        {    
            _context.Departments.Add(department);

            return Task.CompletedTask;
        }

        public async Task<bool> IsDepartmentExist(int departmentId)
        {
            return 
                await _context.Departments.AnyAsync(c => c.Id == departmentId);
        }

        public async Task<bool> SaveChanges()
        {
            bool result =
                await _context.SaveChangesAsync() >= 0;

            return result;
        }

        public Task<Department> UpdateDepartment(Department department)
        {
            throw new NotImplementedException();
        }
    }
}
