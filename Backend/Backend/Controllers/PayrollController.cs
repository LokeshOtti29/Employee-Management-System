using Backend.Dtos.Inputs;
using Backend.Dtos.Outputs;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayrollController : ControllerBase
    {
        private readonly IPayrollServices _service;
        public PayrollController(IPayrollServices service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<PayrollResponseDto>>> GetAllPayroll()
        {
            var payrolls = await _service.GetAllPayroll();
            return Ok(payrolls);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PayrollResponseDto>> GetPayrollByID(int id)
        {
            var payroll = await _service.GetPayrollById(id);
            if (payroll == null)
                return NotFound();
            return Ok(payroll);
        }
        [HttpPost]
        public async Task<ActionResult> CreatePayroll(CreatePayrollPayload payload)
        {
            try
            {
                var result = await _service.CreatePayroll(payload);
                if (!result)
                    return BadRequest("Failed to create payroll");
                return Ok("Payroll created successfully");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePayroll(int id)
        {
            var result = await _service.DeletePayroll(id);
            if (!result)
                return NotFound();
            return Ok("Payroll deleted successfully");
        }
    }
}
