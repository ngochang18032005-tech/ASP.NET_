namespace ASP.Models;

public class Room
{
    public int Id { get; set; }
    public string RoomNumber { get; set; }
    public string Status { get; set; } = "AVAILABLE";
}