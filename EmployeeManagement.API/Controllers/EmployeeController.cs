using EmployeeManagement.API.Models;
using EmploymentManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<ActionResult> Getemployee()
        {
            try
            {
                return Ok(await _employeeRepository.GetEmployees());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> Getemployee(int id)
        {
            try
            {
                var result = await _employeeRepository.GetEmployee(id);
                if(result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            try
            {
                if(employee == null)
                {
                    return BadRequest();
                }
                
                var emp = _employeeRepository.GetEmployeeByEmail(employee.Email);

                // nice solution
                //if(emp != null)
                //{
                //    ModelState.AddModelError("email", "Employee email already in use");
                //    return BadRequest();
                //}

                var createdEmployee = await _employeeRepository.AddEmployee(employee);

                //new style
                // this is will lock pattern of propoty object 
                // not just create any object to database
                return CreatedAtAction(nameof(Getemployee), new { id = createdEmployee.EmployeeId }, createdEmployee);

                //old style
                //return createdEmployee;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id,Employee employee) 
        {
            try
            {
                if(id != employee.EmployeeId)
                {
                    return BadRequest("Employee ID mismatch");
                }

                var employeeToUpdate = await _employeeRepository.GetEmployee(id);
                if(employeeToUpdate == null)
                {
                    return NotFound($"Employee with Id = {id} not found");
                }

                return await _employeeRepository.UpdateEmployee(employee);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data from database");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            try
            {
                var employeeToDelete = await _employeeRepository.GetEmployee(id);
                if(employeeToDelete == null)
                {
                    return NotFound($"Employee with Id = {id} not found");
                }
                return await _employeeRepository.DeleteEmployee(employeeToDelete);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data from database");
            }
        }

        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<Employee>>> Search(string name,Gender gender)
        {
            try
            {
                var result = await _employeeRepository.Search(name, gender);
                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
