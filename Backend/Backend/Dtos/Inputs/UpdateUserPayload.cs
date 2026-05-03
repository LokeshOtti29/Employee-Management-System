namespace Backend.Dtos.Inputs
{
    public class UpdateUserPayload
    {
        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public int RoleId { get; set; }
    }
}
