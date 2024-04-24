using Authentication.Model;
using Authentication.Repositories;
using Authentication.Service;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Repositories
{
    public class EmployeeRepository : IEmployeesRepository
    {
        private readonly DatabaseContext _databaseContext;

        public EmployeeRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;

        }

        // Get all employee details
        public async Task<IEnumerable<Employee>> GetEmployeesDetailsAsync()
        {
            try
            {
                return await _databaseContext.Employees.ToListAsync();

            }
            catch (Exception)
            {
                throw;
            }
        }

        //select an employee
        public async Task<Employee?> GetEmployeeDetailsAsync(int id)
        {
            var desiredEmployee = await _databaseContext.Employees.FindAsync(id);
            if (desiredEmployee is null)
            {
                throw new ArgumentNullException(nameof(Employee));
            }
            return desiredEmployee;
        }


        // Add an employee
        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            try
            {
                _databaseContext.Employees.Add(employee);
                await _databaseContext.SaveChangesAsync();
                return employee;
            }
            catch (Exception)
            {
                throw;
            }
        }


        // update an employee's vacation hours.
        public async Task<Employee> UpdateEmployeeAsync(int id, short vacationHours)
        {
            try
            {
                var existingEmployee = await _databaseContext.Employees.Where(e => e.EmployeeID == id).FirstOrDefaultAsync();

                if (existingEmployee is null)
                {
                    throw new ArgumentException();
                }

                existingEmployee.VacationHours = vacationHours;
                await _databaseContext.SaveChangesAsync();
                return existingEmployee;
            }
            catch (Exception)
            {

                throw;
            }
        }
    
        //remove employee
        public async Task<Employee>DeleteEmployeeAsync (int id)
        {
            try
            {
                var employeeToDelete = await _databaseContext.Employees.FindAsync(id);
                if (employeeToDelete is null)
                {
                    throw new KeyNotFoundException($"Employee with ID {id} not found.");
                }
                _databaseContext.Employees.Remove(employeeToDelete);
                await _databaseContext.SaveChangesAsync();
                return employeeToDelete;
            }
            catch (Exception)
            {

                throw;
            }

        }

        
    }
}

