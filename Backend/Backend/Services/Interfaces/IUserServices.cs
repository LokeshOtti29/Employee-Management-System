using Backend.Dtos.Inputs;
using Backend.Dtos.Outputs;

namespace Backend.Services.Interfaces
{
    public interface IUserServices
    {
        Task<List<UserResponseDto>> GetAllUsers();
        Task<UserResponseDto?> GetUserByID(int id);
        Task<CreateUserPayload> CreateUser(CreateUserPayload payload);

    }
}
