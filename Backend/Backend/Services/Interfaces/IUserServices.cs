using Backend.Dtos.Outputs;

namespace Backend.Services.Interfaces
{
    public interface IUserServices
    {
        Task<List<UserResponseDto>> GetAllUsers();
    }
}
