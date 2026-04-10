using System;

namespace ASP.Models;

public class Order
{
    public int Id { get; set; }
    public int? TableId { get; set; }
    public int? RoomId { get; set; }

    public string Status { get; set; } = "OPEN";
}