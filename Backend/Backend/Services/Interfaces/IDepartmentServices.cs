using Backend.Dtos.Outputs;

namespace Backend.Services.Interfaces
{
    public interface IDepartmentServices
    {
        Task<List<DepartmentResponseDto>> GetAllDepartment();
    }
}
