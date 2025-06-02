using Microsoft.EntityFrameworkCore;
using ProductApp.Data;
using ProductApp.Entities;

namespace ProductApp.Repositories
{
    public class EmployeeRepository
    {
        public readonly DataContext _context;

        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }


        public List<EmployeeModel> GetEmployees()
        {
            return _context.Employees
                .FromSqlRaw("CALL GetEmployees()")
                .ToList();
        }
        public bool AddEmployee(EmployeeModel employee)
        {
            var result = _context.Database.ExecuteSqlRaw("CALL InsertEmployee({0}, {1}, {2})", employee.Name, employee.City, employee.Address);

            if (result >= 1)
                return true;
            else
                return false;
        }

        public bool UpdateEmployee(EmployeeModel employee)
        {
            var result = _context.Database.ExecuteSqlRaw("CALL UpdateEmployee({0}, {1}, {2}, {3})", employee.EmpId, employee.Name, employee.City, employee.Address);

            if (result >= 1)
                return true;
            else
                return false;
        }

        public bool DeleteEmployee(int id)
        {
            var result = _context.Database.ExecuteSqlRaw("CALL DeleteEmployee({0})", id);

            if (result >= 1)
                return true;
            else
                return false;
        }
    }
}
