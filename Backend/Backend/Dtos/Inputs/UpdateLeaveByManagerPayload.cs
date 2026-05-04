namespace Backend.Dtos.Inputs
{
    public class UpdateLeaveByManagerPayload
    {
        public string Status { get; set; } = string.Empty; 

        public int ApprovedBy { get; set; }
    }
}
