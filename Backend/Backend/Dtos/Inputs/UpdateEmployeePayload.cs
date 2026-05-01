namespace Backend.Dtos.Inputs
{
    public class UpdateEmployeePayload
    {
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        public int DepartmentId { get; set; }

        public string Designation { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;
    }
}
