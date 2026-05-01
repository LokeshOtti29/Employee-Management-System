using Backend.Dtos.Outputs;

namespace Backend.Services.Interfaces
{
    public interface IEmployeeServices
    {
        Task<List<EmployeeResponseDto>> GetAllEmployees();
    }
}
