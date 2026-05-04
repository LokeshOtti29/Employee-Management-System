namespace Backend.Dtos.Outputs
{
    public class LeaveResponseDto
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = string.Empty;

        public int LeaveTypeId { get; set; }
        public string LeaveTypeName { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int TotalDays { get; set; }

        public string Reason { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public DateTime AppliedDate { get; set; }

        public int? ApprovedBy { get; set; }
        public string? ApprovedByName { get; set; }
    }
}
