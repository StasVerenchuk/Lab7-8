using Microsoft.EntityFrameworkCore;
using ProductApp.Entities;

namespace ProductApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<EmployeeModel> Employees { get; set; }
    }
}
