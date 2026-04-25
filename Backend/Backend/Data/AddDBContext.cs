using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class AddDBContext : DbContext
    {
        public AddDBContext(DbContextOptions<AddDBContext> options)
            : base(options)
        {
        }

        public DbSet<Roles> Roles => Set<Roles>();
        public DbSet<Users> Users => Set<Users>();
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Department> Departments => Set<Department>();
        public DbSet<Leave> Leaves => Set<Leave>();
        public DbSet<LeaveType> LeaveTypes => Set<LeaveType>();
        public DbSet<Payroll> Payrolls => Set<Payroll>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payroll>()
                .Property(p => p.BasicSalary)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Payroll>()
                .Property(p => p.Bonus)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Payroll>()
                .Property(p => p.Deductions)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Payroll>()
                .Property(p => p.NetSalary)
                .HasPrecision(18, 2);

            base.OnModelCreating(modelBuilder);
        }
    }
}