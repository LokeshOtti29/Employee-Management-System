namespace Backend.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        public int DepartmentId { get; set; }
        public Department Department { get; set; } = null!;

        public string Designation { get; set; } = string.Empty;

        public DateOnly DateOfJoining { get; set; }

        public string Status { get; set; } = "Active";

        public string ProfilePicture { get; set; } = string.Empty;

        public int UserId { get; set; }
        public Users User { get; set; } = null!;

        public List<Leave> Leaves { get; set; } = new();

        public List<Payroll> Payrolls { get; set; } = new();
    }
}