using HRAPI.DbContexts;
using HRAPI.Models;

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

        public async Task<Department> InsertDepartment(Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            
            return department;
        }

        public Task<Department> UpdateDepartment(Department department)
        {
            throw new NotImplementedException();
        }
    }
}
