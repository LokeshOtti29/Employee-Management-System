using Backend.Dtos.Inputs;
using Backend.Dtos.Outputs;
using Backend.Models;

namespace Backend.Services.Interfaces
{
    public interface IAuthServices
    {
        Task<Users?> Register(CreateUserPayload payload);
        Task<String?> Login(LoginDto payload);
    }
}
