using HRAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace HRAPI.DbContexts
{
    public class HRContext : DbContext
    {
        public DbSet<Department> Departments { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;

        public HRContext(DbContextOptions options) 
            : base(options)
        {

        }
    }
}
