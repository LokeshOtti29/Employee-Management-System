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
    }
}
