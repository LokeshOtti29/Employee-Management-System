using Backend.Data;
using Backend.Dtos.Inputs;
using Backend.Dtos.Outputs;
using Backend.Models;
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
            return await _context.Employees.Select(e => new EmployeeResponseDto{
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

        public async Task<EmployeeResponseDto?> GetEmployeeByID(int id)
        {
            return await _context.Employees.Where(e => e.Id == id).Select(e => new EmployeeResponseDto
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
            }).FirstOrDefaultAsync();
        }
        public async Task<EmployeeResponseDto> CreateEmployee(CreateEmployeePayload payload)
        {
            var department = await _context.Departments.FindAsync(payload.DepartmentId);

            if (department == null)
                throw new KeyNotFoundException("Department not found");

            var employee = new Employee
            {
                Firstname = payload.Firstname,
                Lastname = payload.Lastname,
                Email = payload.Email,
                Phone = payload.Phone,
                DepartmentId = payload.DepartmentId,
                Designation = payload.Designation,
                DateOfJoining = payload.DateOfJoining,
                ProfilePicture = payload.ProfilePicture,
                UserId = payload.UserId,       
                Status = "Active"               
            };

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return new EmployeeResponseDto
            {
                Id = employee.Id,
                Firstname = employee.Firstname,
                Lastname = employee.Lastname,
                Email = employee.Email,
                Phone = employee.Phone,
                DepartmentName = department.Name,
                Designation = employee.Designation,
                DateOfJoining = employee.DateOfJoining,
                Status = employee.Status,
                ProfilePicture = employee.ProfilePicture
            };
        }
        public async Task<bool> UpdateEmployee(int id, UpdateEmployeePayload payload)
        {
            var employee = await _context.Employees.FindAsync(id);
            if(employee == null)
            {
                return false;
            }
            var department = await _context.Departments.FindAsync(payload.DepartmentId);
            if(department == null)
            {
                return false;
            }
            employee.Firstname = payload.Firstname;
            employee.Lastname = payload.Lastname;
            employee.Email = payload.Email;
            employee.Phone = payload.Phone;
            employee.DepartmentId = payload.DepartmentId;
            employee.Designation = payload.Designation;
            employee.Status = payload.Status;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
