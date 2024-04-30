using Authentication.Model;
using Authentication.Repositories;

namespace Authentication.Service
{
    /// <summary>
    /// Interface for interacting with employee data repository.
    /// </summary>
    public interface IEmployeesRepository
    {
        /// <summary>
        /// Retrieves details of all employees asynchronously.
        /// </summary>
        /// <returns>An asynchronous operation returning a collection of Employee objects.</returns>
        Task<IEnumerable<Employee>> GetEmployeesDetailsAsync();

        /// <summary>
        /// Retrieves details of a specific employee asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the employee.</param>
        /// <returns>An asynchronous operation returning the Employee object if found, otherwise null.</returns>
        Task<Employee?> GetEmployeeDetailsAsync(int id);

        /// <summary>
        /// Adds a new employee asynchronously.
        /// </summary>
        /// <param name="employee">The Employee object representing the employee to be added.</param>
        /// <returns>An asynchronous operation returning the added Employee object.</returns>
        Task<Employee> AddEmployeeAsync(Employee employee);

        /// <summary>
        /// Updates vacation hours for a specific employee asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the employee.</param>
        /// <param name="vacationHours">The new value of vacation hours.</param>
        /// <returns>An asynchronous operation returning the updated Employee object.</returns>
        Task<Employee> UpdateEmployeeAsync(int id, short vacationHours);

        /// <summary>
        /// Deletes a specific employee asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the employee to be deleted.</param>
        /// <returns>An asynchronous operation returning the deleted Employee object.</returns>
        Task<Employee> DeleteEmployeeAsync(int id);
    }

}

