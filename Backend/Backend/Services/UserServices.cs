using Backend.Data;
using Backend.Dtos.Outputs;
using Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class UserServices: IUserServices
    {
        public readonly AddDBContext _context;
        public UserServices(AddDBContext context)
        {
            _context = context;
        }

        public async Task<List<UserResponseDto>> GetAllUsers()
        {
            return await _context.Users.Select(u => new UserResponseDto
            {
                Id = u.ID,
                Name = u.name,
                Email = u.email,
                RoleName = u.Role.Name
            }).ToListAsync();
        }
    }
}
