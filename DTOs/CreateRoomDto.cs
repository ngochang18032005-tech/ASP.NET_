using System.ComponentModel.DataAnnotations;

namespace ASP.DTOs;

public class CreateRoomDto
{
    [Required]
    public string RoomNumber { get; set; }

    [Required]
    public string Status { get; set; }
}