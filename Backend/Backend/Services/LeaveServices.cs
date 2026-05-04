using Backend.Data;
using Backend.Dtos.Inputs;
using Backend.Dtos.Outputs;
using Backend.Models;
using Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class LeaveServices : ILeaveServices
    {
        public readonly AddDBContext _context;
        public LeaveServices(AddDBContext context)
        {
            _context = context;
        }

        public async Task<List<LeaveResponseDto>> GetAllLeaves()
        {
            return await _context.Leaves
                .Select(l => new LeaveResponseDto
                {
                    Id = l.Id,
                    EmployeeId = l.EmployeeId,
                    LeaveTypeId = l.LeaveTypeId,
                    StartDate = l.StartDate,
                    EndDate = l.EndDate,
                    Reason = l.Reason,
                    Status = l.Status,
                    AppliedDate = l.AppliedDate,
                    ApprovedBy = l.ApprovedBy
                })
                .ToListAsync();
        }

        public async Task<LeaveResponseDto?> GetLeaveByID(int id)
        {
            return await _context.Leaves
                .Where(l => l.Id == id)
                .Select(l => new LeaveResponseDto
                {
                    Id = l.Id,
                    EmployeeId = l.EmployeeId,
                    LeaveTypeId = l.LeaveTypeId,
                    StartDate = l.StartDate,
                    EndDate = l.EndDate,
                    Reason = l.Reason,
                    Status = l.Status,
                    AppliedDate = l.AppliedDate,
                    ApprovedBy = l.ApprovedBy
                })
                .FirstOrDefaultAsync();
        }

        public async Task<LeaveResponseDto> CreateLeave(CreateLeavesPayload payload)
        {
            var leaveType = await _context.LeaveTypes.FindAsync(payload.LeaveTypeId);
            if (leaveType == null)
                throw new KeyNotFoundException("Leave type not found");
            var leave = new Leave
            {
                EmployeeId = payload.EmployeeId,
                LeaveTypeId = payload.LeaveTypeId,
                StartDate = payload.StartDate,
                EndDate = payload.EndDate,
                Reason = payload.Reason,
                Status = "Pending",
                AppliedDate = DateTime.UtcNow
            };
            _context.Leaves.AddAsync(leave);
            await _context.SaveChangesAsync();
            return new LeaveResponseDto
            {
                Id = leave.Id,
                EmployeeId = leave.EmployeeId,
                LeaveTypeId = leave.LeaveTypeId,
                StartDate = leave.StartDate,
                EndDate = leave.EndDate,
                Reason = leave.Reason,
                Status = leave.Status,
                AppliedDate = leave.AppliedDate
            };
        }
        public async Task<LeaveResponseDto> UpdateLeave(int id, UpdateLeavePayload payload)
        {
            var leave = await _context.Leaves.FindAsync(id);

            if (leave == null)
                throw new KeyNotFoundException("Leave not found");

            if (leave.Status != "Pending")
                throw new Exception("Only pending leaves can be updated");

            leave.LeaveTypeId = payload.LeaveTypeId;
            leave.StartDate = payload.StartDate;
            leave.EndDate = payload.EndDate;
            leave.Reason = payload.Reason;

            await _context.SaveChangesAsync();

            return new LeaveResponseDto
            {
                Id = leave.Id,
                EmployeeId = leave.EmployeeId,
                LeaveTypeId = leave.LeaveTypeId,
                StartDate = leave.StartDate,
                EndDate = leave.EndDate,
                Reason = leave.Reason,
                Status = leave.Status,
                AppliedDate = leave.AppliedDate,
                ApprovedBy = leave.ApprovedBy
            };
        }
        public async Task<LeaveResponseDto> ApproveLeave(int id, UpdateLeaveByManagerPayload payload)
        {
            var leave = await _context.Leaves.FindAsync(id);
            if (leave == null)
                throw new KeyNotFoundException("Leave not found");
            if (leave.Status != "Pending")
                throw new Exception("Only pending leaves can be approved");
            leave.Status = payload.Status;
            leave.ApprovedBy = payload.ApprovedBy;
            await _context.SaveChangesAsync();
            return new LeaveResponseDto
            {
                Id = leave.Id,
                EmployeeId = leave.EmployeeId,
                LeaveTypeId = leave.LeaveTypeId,
                StartDate = leave.StartDate,
                EndDate = leave.EndDate,
                Reason = leave.Reason,
                Status = leave.Status,
                AppliedDate = leave.AppliedDate,
                ApprovedBy = leave.ApprovedBy
            };
        }
        public async Task DeleteLeave(int id)
        {
            var leave = await _context.Leaves.FindAsync(id);
            if (leave == null)
                throw new KeyNotFoundException("Leave not found");
            if (leave.Status != "Pending")
                throw new Exception("Only pending leaves can be deleted");
            _context.Leaves.Remove(leave);
            await _context.SaveChangesAsync();
        }
    }
}
