using Backend.Dtos.Inputs;
using Backend.Dtos.Outputs;

namespace Backend.Services.Interfaces
{
    public interface IPayrollServices
    {
        Task<List<PayrollResponseDto>> GetAllPayroll();
        Task<PayrollResponseDto?> GetPayrollById(int id);
        Task<bool> CreatePayroll(CreatePayrollPayload payload);
        Task<bool> DeletePayroll(int id);
    }
}
