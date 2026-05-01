namespace Backend.Dtos.Outputs
{
    public class EmployeeResponseDto
    {
        public int Id { get; set; }

        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        public string DepartmentName { get; set; } = string.Empty;

        public string Designation { get; set; } = string.Empty;

        public DateOnly DateOfJoining { get; set; }

        public string Status { get; set; } = string.Empty;

        public string ProfilePicture { get; set; } = string.Empty;
    }
}
