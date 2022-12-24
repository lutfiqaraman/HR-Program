using AutoMapper;
using HRAPI.DbContexts;
using HRAPI.Entities;
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

        public async Task<IEnumerable<EmployeeDto>> GetAllEmployees()
        {
            List<Employee> lstEmployees =
                await context.Employees.Include(e => e.Department).ToListAsync();

            IEnumerable<EmployeeDto> employees =
                mapper.Map<IEnumerable<EmployeeDto>>(lstEmployees);

            return employees;
        }

        public async Task<EmployeeDto?> GetEmployeeByID(int employeeId)
        {
            Employee? employeeFromDB = 
                await context
                .Employees
                .Include(e => e.Department)
                .SingleOrDefaultAsync(e => e.Id == employeeId);

            EmployeeDto employee = 
                mapper.Map<EmployeeDto>(employeeFromDB);

            return employee;
        }

        public async Task AddEmployee(CreateEmployeeDto employee)
        {
            try
            {
                Employee? mappedEmployee =
                    mapper.Map<Employee>(employee);

                context.Employees.Add(mappedEmployee);

                await
                    SaveChanges();
            }
            catch (Exception ex)
            {
                if (ex.Source != null)
                    throw new Exception(ex.Message);

                throw;
            }
        }

        public async Task<Employee?> UpdateEmployee(int employeeId, UpdateEmployeeDto updateEmployeeDto)
        {
            try
            {
                updateEmployeeDto.Id = employeeId;

                Employee? employee =
                    mapper.Map<Employee>(updateEmployeeDto);

                if (employee != null)
                {
                    context.Entry(employee).State = EntityState.Modified;
                    await SaveChanges();
                }

                return employee;
            }
            catch (Exception ex)
            {
                if (ex.Source != null)
                    throw new Exception(ex.Message);

                throw;
            }
        }

        public async Task<bool> DeleteEmployee(int employeeId)
        {
            try
            {
                bool result = false;

                Employee? employee =
                    context.Employees.FirstOrDefault(e => e.Id == employeeId);

                if (employee != null)
                {
                    context.Entry(employee).State = EntityState.Deleted;
                    await SaveChanges();

                    result = true;

                    return result;
                }

                return result;
            }
            catch (Exception ex)
            {
                if (ex.Source != null)
                    throw new Exception(ex.Message);

                throw;
            }
        }

        public async Task<bool> SaveChanges()
        {
            try
            {
                bool result =
                    await context.SaveChangesAsync() >= 0;

                return result;
            }
            catch (Exception ex)
            {
                if (ex.Source != null)
                    throw new Exception(ex.Message);
                
                throw;
            }

        }
    }
}
