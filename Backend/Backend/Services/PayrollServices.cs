using Backend.Data;
using Backend.Dtos.Inputs;
using Backend.Dtos.Outputs;
using Backend.Models;
using Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class PayrollServices : IPayrollServices
    {
        private readonly AddDBContext _context;
        public PayrollServices(AddDBContext context)
        {
            _context = context;
        }
        public async Task<List<PayrollResponseDto>> GetAllPayroll()
        {
            return await _context.Payrolls.Select(p => new PayrollResponseDto
            {
                Id = p.Id,
                EmployeeId = p.EmployeeId,
                EmployeeName = p.Employee.Firstname + " " + p.Employee.Lastname,
                Month = p.Month,
                Year = p.Year,
                BasicSalary = p.BasicSalary,
                Bonus = p.Bonus,
                Deductions = p.Deductions,
                NetSalary = p.NetSalary,
                GeneratedDate = p.GeneratedDate
            }).ToListAsync();
        }
        public async Task<PayrollResponseDto?> GetPayrollById(int id)
        {
            return await _context.Payrolls.Where(p => p.Id == id).Select(p => new PayrollResponseDto
            {
                Id = p.Id,
                EmployeeId = p.EmployeeId,
                EmployeeName = p.Employee.Firstname + " " + p.Employee.Lastname,
                Month = p.Month,
                Year = p.Year,
                BasicSalary = p.BasicSalary,
                Bonus = p.Bonus,
                Deductions = p.Deductions,
                NetSalary = p.NetSalary,
                GeneratedDate = p.GeneratedDate
            }).FirstOrDefaultAsync();
        }

        public async Task<bool> CreatePayroll(CreatePayrollPayload payload)
        {
            var payroll = new Payroll
            {
                EmployeeId = payload.EmployeeId,
                Month = payload.Month,
                Year = payload.Year,
                BasicSalary = payload.BasicSalary,
                Bonus = payload.Bonus,
                Deductions = payload.Deductions,
                NetSalary = payload.NetSalary,
                GeneratedDate = DateTime.Now
            };
            _context.Payrolls.AddAsync(payroll);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeletePayroll(int id)
        {
            var payroll = await _context.Payrolls.FindAsync(id);
            if(payroll == null)
            {
                return false;
            }
            _context.Payrolls.Remove(payroll);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
