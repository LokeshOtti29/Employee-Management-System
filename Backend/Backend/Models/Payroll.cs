namespace Backend.Models
{
    public class Payroll
    {
        public int Id { get; set; }

        // FK -> Employees.Id
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; } = null!;

        public int Month { get; set; }

        public int Year { get; set; }

        public decimal BasicSalary { get; set; }

        public decimal Bonus { get; set; }

        public decimal Deductions { get; set; }

        public decimal NetSalary { get; set; }

        public DateTime GeneratedDate { get; set; } = DateTime.Now;
    }
}