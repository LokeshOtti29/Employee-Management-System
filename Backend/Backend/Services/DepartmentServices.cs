using Backend.Data;
using Backend.Dtos.Outputs;
using Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class DepartmentServices : IDepartmentServices
    {
        private readonly AddDBContext _context;
        public DepartmentServices(AddDBContext context)
        {
            _context = context;
        }
        public async Task<List<DepartmentResponseDto>> GetAllDepartment()
        {
            return await _context.Departments.Select(d => new DepartmentResponseDto
            {
                Id = d.Id,
                Name = d.Name
            }).ToListAsync();
        }
    }
}
