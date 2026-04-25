namespace Backend.Models
{
    public class Users
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int RoleId { get; set; }
        public Roles Role { get; set; } = null!;
        public List<Employee> Employee { get; set; } = new();
    }
}
