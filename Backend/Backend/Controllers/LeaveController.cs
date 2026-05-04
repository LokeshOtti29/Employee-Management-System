using Backend.Dtos.Inputs;
using Backend.Dtos.Outputs;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveController : ControllerBase
    {
        public readonly ILeaveServices _service;
        public LeaveController(ILeaveServices service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<List<LeaveResponseDto>>> GetAllLeaves()
        {
            var leaves = await _service.GetAllLeaves();
            return Ok(leaves);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveResponseDto>> GetLeaveByID(int id)
        {
            var leave = await _service.GetLeavesById(id);
            if (leave == null)
                return NotFound();
            return Ok(leave);
        }

        [HttpPost]
        public async Task<ActionResult<LeaveResponseDto>> CreateLeave(CreateLeavesPayload payload)
        {
            try
            {
                var leave = await _service.CreateLeave(payload);
                return Ok(leave);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateLeave(int id, UpdateLeavePayload payload)
        {
            try
            {
                var result = await _service.UpdateLeave(id, payload);
                if (!result)
                    return NotFound();
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPut("{id}/status")]
        public async Task<ActionResult> UpdateLeaveByManager(int id, UpdateLeaveByManagerPayload payload)
        {
            try
            {
                var result = await _service.UpdateLeaveByManager(id, payload);
                if (!result)
                    return NotFound();
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLeave(int id)
        {
            var result = await _service.DeleteLeave(id);
            if (!result)
                return NotFound();
            return NoContent();
        }
    }
}
