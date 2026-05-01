namespace Backend.Dtos.Inputs
{
    public class CreateEmployeePayload
    {
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        public int DepartmentId { get; set; }

        public string Designation { get; set; } = string.Empty;

        public DateOnly DateOfJoining { get; set; }

        public int UserId { get; set; }
    }
}
