using AutoMapper;
using HRAPI.DbContexts;
using HRAPI.Entities;
using HRAPI.Models.EmployeeDtos;

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

        public Task<IEnumerable<EmployeeDto>> GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        public Task<Employee?> GetEmployeeByID(int employeeId)
        {
            throw new NotImplementedException();
        }
    }
}
