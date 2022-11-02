using AutoMapper;
using HRAPI.DbContexts;

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

        public Task GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        public Task GetEmployeeByID(int employeeId)
        {
            throw new NotImplementedException();
        }
    }
}
