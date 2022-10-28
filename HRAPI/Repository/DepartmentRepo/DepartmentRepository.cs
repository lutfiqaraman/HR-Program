using AutoMapper;
using HRAPI.DbContexts;
using HRAPI.Entities;
using HRAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HRAPI.Repository.DepartmentRepo
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly HRContext _context;
        private readonly IMapper mapper;

        public DepartmentRepository(HRContext context, IMapper Mapper)
        {
            _context = 
                context ?? throw new ArgumentNullException(nameof(context));

            mapper =
                Mapper ?? throw new ArgumentNullException(nameof(Mapper));
        }

        public async Task<Department?> GetDepartmentByID(int departmentId)
        {
            return 
                await _context
                .Departments
                .Where(d => d.Id == departmentId).SingleOrDefaultAsync();
        }

        public Task<IEnumerable<Department>> GetAllDepartments()
        {
            throw new NotImplementedException();
        }

        public async Task AddDepartment(CreateDepartmentDto department)
        {
            Department? mappedDepartment =
                mapper.Map<Department>(department);

            _context.Departments.Add(mappedDepartment);

            await 
                SaveChanges();
        }

        public async Task<Department?> UpdateDepartment(int departmentId, UpdateDepartmentDto department)
        {
            Department? departmentEntity =
                await GetDepartmentByID(departmentId);

            Department? mappedDepartment =
                mapper.Map(department, departmentEntity);

            if (mappedDepartment != null)
            {
                _context.Entry(mappedDepartment).State = EntityState.Modified;
                await SaveChanges();
            }

            return mappedDepartment;
        }

        public bool DeleteDepartment(int id)
        {
            throw new NotImplementedException();
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
    }
}
