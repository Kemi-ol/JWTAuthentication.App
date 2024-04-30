using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Authentication.Model;
using Authentication.Repositories;
using Authentication.Service;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel;

namespace Authentication.Controllers
{

   
    [Route("api/v{version:apiVersion}/employee")]
    [ApiController]
   [Authorize]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesRepository _employeesRepository;

        public EmployeesController(IEmployeesRepository employeeRepository)
        {
            _employeesRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }



        /// <summary>
        /// Get all employees
        /// </summary>
        /// <returns> All Employees</returns>
        /// <response code = "200"> Returns all employees </response>
       
        // GET: api/Employees- get all employees
        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var employees = await _employeesRepository.GetEmployeesDetailsAsync();
            return Ok(employees);
        }


        /// <summary>
        /// Get a specific employee by id
        /// </summary>
        /// <param name="id">The id of the Employee</param>
        /// <returns>An Employee for a specific id</returns>
        //GET: api/Employees/1- get a single employee
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _employeesRepository.GetEmployeeDetailsAsync(id);
            return Ok(employee);
        }


        /// <summary>
        /// Add an Employee
        /// </summary>
        /// <param name="employee">The details of the employee</param>
        /// <returns>The added employee</returns>
        //POST: api/Employee/add - add an employee
        [HttpPost("/add-employee")]
        public async Task<ActionResult<Employee>> AddnewEmployee(Employee employee)
        {
            var newEmployee = await _employeesRepository.AddEmployeeAsync(employee);

            return Ok(newEmployee);
        }


        /// <summary>
        /// Update Vacatiion hours of an employee
        /// </summary>
        /// <param name="id">The id of the employee</param>
        /// <param name="vacationHours">The new number of hours</param>
        /// <returns>The updated Employee details</returns>
 
        //update an employee
        [HttpPut("/update/{id}")]
        public async Task<ActionResult<Employee>> UpdateEmployee( int id, short vacationHours)
        {
           var updatedEmployee =  await _employeesRepository.UpdateEmployeeAsync(id, vacationHours);
            return Ok(updatedEmployee);
        }

        
        /// <summary>
        /// Delete An Employee
        /// </summary>
        /// <param name="id">The id of the employee</param>
        /// <returns>status</returns>
        //Delete an employee
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            var employeeToDelete = await _employeesRepository.DeleteEmployeeAsync(id);
            if (employeeToDelete != null)
            {
                return NoContent();
            }
            return NotFound();

        } 
    }
}
