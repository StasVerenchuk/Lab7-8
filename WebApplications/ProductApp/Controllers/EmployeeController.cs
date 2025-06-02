using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Entities;
using ProductApp.Repositories;

namespace ProductApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeRepository _repo;

        public EmployeeController(EmployeeRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("GetEmployees")]
        public IActionResult GetEmployees()
        {
            try
            {
                var employees = _repo.GetEmployees();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("AddEmployee")]
        public IActionResult AddEmployee([FromBody] EmployeeModel employee)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (_repo.AddEmployee(employee))
                {
                    return Ok("Employee details added successfully.");
                }
                else
                    return StatusCode(500, $"Failed to add employee details.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("UpdateEmployee/{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] EmployeeModel employee)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                employee.EmpId = id;

                if (_repo.UpdateEmployee(employee))
                {
                    return Ok("Employee details updated successfully.");
                }
                else
                    return StatusCode(500, $"Failed to update employee details.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("DeleteEmployee/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                if (_repo.DeleteEmployee(id))
                {
                    return Ok("Employee details deleted successfully.");
                }
                else
                    return NotFound("Employee not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
