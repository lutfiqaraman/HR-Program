using AutoMapper;
using HRAPI.DbContexts;
using HRAPI.Entities;
using HRAPI.Models.DepartmentDtos;
using HRAPI.Models.EmployeeDtos;
using Microsoft.EntityFrameworkCore;

namespace HRAPI.Repository.EmployeeRepo
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly HRContext context;
        private readonly IMapper mapper;

        public EmployeeRepository(HRContext Context, IMapper Mapper)
        {
            context =
                Context ?? throw new ArgumentNullException(nameof(Context));

            mapper =
                Mapper ?? throw new ArgumentNullException(nameof(Mapper));
        }

        public Task AddEmployee()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllEmployees()
        {
            List<Employee> lstEmployees =
                await context.Employees.ToListAsync();

            IEnumerable<EmployeeDto> employees =
                mapper.Map<IEnumerable<EmployeeDto>>(lstEmployees);

            return employees;
        }

        public async Task<EmployeeDto?> GetEmployeeByID(int employeeId)
        {
            Employee? employeeFromDB = 
                await context
                .Employees
                .Where(d => d.Id == employeeId).SingleOrDefaultAsync();

            EmployeeDto employee = 
                mapper.Map<EmployeeDto>(employeeFromDB);

            return employee;
        }
    }
}
