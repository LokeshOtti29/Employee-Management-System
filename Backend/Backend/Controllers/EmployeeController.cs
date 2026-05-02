using Backend.Dtos.Inputs;
using Backend.Dtos.Outputs;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public readonly IEmployeeServices _services;

        public EmployeeController(IEmployeeServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployeeResponseDto>>> GetAllEmployees()
        {
            var employees = await _services.GetAllEmployees();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeResponseDto>> GetEmployeeByID(int id)
        {
            var employee = await _services.GetEmployeeByID(id);
            if (employee == null)
                return NotFound();
            return Ok(employee);
        }

        [HttpPost]

        public async Task<ActionResult<EmployeeResponseDto>> CreateEmployee(CreateEmployeePayload payload)
        {
            try
            {
                var employee = await _services.CreateEmployee(payload);
                return Ok(employee);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEmployee(int id, UpdateEmployeePayload payload)
        {
            try
            {
                var result = await _services.UpdateEmployee(id, payload);
                if (!result)
                    return NotFound();
                return Ok("Updated successfully");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            var result = await _services.DeleteEmployee(id);
            if (!result)
                return NotFound();
            return Ok("Deleted successfully");
        }
    }
}
