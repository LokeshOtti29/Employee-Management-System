using Backend.Dtos.Inputs;
using Backend.Dtos.Outputs;

namespace Backend.Services.Interfaces
{
    public interface ILeaveServices
    {
        Task<List<LeaveResponseDto>> GetAllLeaves();
        Task<LeaveResponseDto?> GetLeavesById(int id);
        Task<LeaveResponseDto> CreateLeave(CreateLeavesPayload payload);
        Task<bool> UpdateLeave(int id, UpdateLeavePayload payload);
        Task<bool> UpdateLeaveByManager(int id, UpdateLeaveByManagerPayload payload);
        Task<bool> DeleteLeave(int id);
    }
}
