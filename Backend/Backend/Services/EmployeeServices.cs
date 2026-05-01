using Backend.Data;
using Backend.Dtos.Outputs;
using Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class EmployeeServices: IEmployeeServices
    {
        public readonly AddDBContext _context;
        public EmployeeServices(AddDBContext context)
        {
            _context = context;
        }

        public async Task<List<EmployeeResponseDto>> GetAllEmployees()
        {
            return await _context.Employees.Include(e => e.Department)
                .Select(e => new EmployeeResponseDto
                {
                    Id = e.Id,
                    Firstname = e.Firstname,
                    Lastname = e.Lastname,
                    Email = e.Email,
                    Phone = e.Phone,
                    DepartmentName = e.Department.Name,
                    Designation = e.Designation,
                    DateOfJoining = e.DateOfJoining,
                    Status = e.Status,
                    ProfilePicture = e.ProfilePicture
                }).ToListAsync();
        }
    }
}
