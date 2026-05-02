using Backend.Dtos.Inputs;
using Backend.Dtos.Outputs;

namespace Backend.Services.Interfaces
{
    public interface IEmployeeServices
    {
        Task<List<EmployeeResponseDto>> GetAllEmployees();
        Task<EmployeeResponseDto?> GetEmployeeByID(int id);
        Task<EmployeeResponseDto> CreateEmployee(CreateEmployeePayload payload);
        Task<bool> UpdateEmployee(int id, UpdateEmployeePayload payload);
    }
}
