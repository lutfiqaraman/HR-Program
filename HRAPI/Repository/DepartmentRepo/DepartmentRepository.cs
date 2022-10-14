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

        public Task<Department> InsertDepartment(Department department)
        {
            throw new NotImplementedException();
        }

        public Task<Department> UpdateDepartment(Department department)
        {
            throw new NotImplementedException();
        }
    }
}
