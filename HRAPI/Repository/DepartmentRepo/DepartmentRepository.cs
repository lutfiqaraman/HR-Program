using AutoMapper;
using HRAPI.DbContexts;
using HRAPI.Entities;
using HRAPI.Models.DepartmentDtos;
using Microsoft.EntityFrameworkCore;

namespace HRAPI.Repository.DepartmentRepo
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly HRContext context;
        private readonly IMapper mapper;

        public DepartmentRepository(HRContext Context, IMapper Mapper)
        {
            context = 
                Context ?? throw new ArgumentNullException(nameof(Context));

            mapper =
                Mapper ?? throw new ArgumentNullException(nameof(Mapper));
        }

        public async Task<Department?> GetDepartmentByID(int departmentId)
        {
            return 
                await context
                .Departments
                .Where(d => d.Id == departmentId).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<DepartmentDto>> GetAllDepartments()
        {
            List<Department> lstDepartments = 
                await context.Departments.ToListAsync();

            IEnumerable<DepartmentDto> departments =
                mapper.Map<IEnumerable<DepartmentDto>>(lstDepartments);

            return departments;
        }

        public async Task AddDepartment(CreateDepartmentDto department)
        {
            Department? mappedDepartment =
                mapper.Map<Department>(department);

            context.Departments.Add(mappedDepartment);

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
                context.Entry(mappedDepartment).State = EntityState.Modified;
                await SaveChanges();
            }

            return mappedDepartment;
        }

        public async Task<bool> DeleteDepartment(int departmentId)
        {
            bool result = false;

            Department? departmentEntity =
                await GetDepartmentByID(departmentId);

            if (departmentEntity != null)
            {
                context.Entry(departmentEntity).State = EntityState.Deleted;
                await SaveChanges();

                result = true;

                return result;
            }

            return result;
        }

        public async Task<bool> IsDepartmentExist(int departmentId)
        {
            return 
                await context.Departments.AnyAsync(c => c.Id == departmentId);
        }

        public async Task<bool> SaveChanges()
        {
            bool result =
                await context.SaveChangesAsync() >= 0;

            return result;
        }
    }
}
