using Backend.Dtos.Outputs;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentServices _service;
        public DepartmentController(IDepartmentServices service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<DepartmentResponseDto>>> GetAllDepartment()
        {
            var departments = await _service.GetAllDepartment();
            return Ok(departments);
        }
    }
}
