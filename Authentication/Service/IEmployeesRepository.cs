using Authentication.Model;
using Authentication.Repositories;

namespace Authentication.Service
{
    public interface IEmployeesRepository
    {
       Task <IEnumerable<Employee>> GetEmployeesDetailsAsync();
       Task <Employee?> GetEmployeeDetailsAsync(int id);
       Task <Employee>AddEmployeeAsync(Employee employee);
        Task <Employee>UpdateEmployeeAsync(int id, short vacationHours);
        Task <Employee> DeleteEmployeeAsync(int id);
       
    }
}
