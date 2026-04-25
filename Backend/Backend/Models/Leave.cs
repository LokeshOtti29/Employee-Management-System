namespace Backend.Models
{
    public class Leave
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public int LeaveTypeId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Reason { get; set; } = string.Empty;

        public string Status { get; set; } = "Pending";

        public DateTime AppliedDate { get; set; } = DateTime.Now;

        public int? ApprovedBy { get; set; }

        public Employee Employee { get; set; } = null!;

        public LeaveType LeaveType { get; set; } = null!;

        public Users? Approver { get; set; }
    }
}