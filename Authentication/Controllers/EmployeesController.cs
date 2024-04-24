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

namespace Authentication.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
     
        private readonly IEmployeesRepository _employeesRepository;

        public EmployeesController(IEmployeesRepository employeeRepository)
        {
            _employeesRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }




        // GET: api/Employees- get all employees
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var employees = await _employeesRepository.GetEmployeesDetailsAsync();
            return Ok(employees);
        }



        //GET: api/Employees/1- get a single employee
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _employeesRepository.GetEmployeeDetailsAsync(id);
            return Ok(employee);
        }




        //POST: api/Employee/add - add an employee
        [HttpPost("/add-employee")]
        public async Task<ActionResult<Employee>> AddnewEmployee(Employee employee)
        {
            var newEmployee = await _employeesRepository.AddEmployeeAsync(employee);

            return Ok(newEmployee);
        }




        //update an employee
        [HttpPut("/update/{id}")]
        public async Task<ActionResult<Employee>> UpdateEmployee( int id, short vacationHours)
        {
           var updatedEmployee =  await _employeesRepository.UpdateEmployeeAsync(id, vacationHours);
            return Ok(updatedEmployee);
        }

        ,

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
