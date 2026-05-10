namespace Backend.Dtos.Outputs
{
    public class PayrollResponseDto
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; } = string.Empty;

        public int Month { get; set; }

        public int Year { get; set; }

        public decimal BasicSalary { get; set; }

        public decimal Bonus { get; set; }

        public decimal Deductions { get; set; }

        public decimal NetSalary { get; set; }

        public DateTime GeneratedDate { get; set; }
    }
}
