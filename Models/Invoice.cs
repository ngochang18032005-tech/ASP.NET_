using System;

namespace ASP.Models;

public class Invoice
{
    public int Id { get; set; }

    public int BookingId { get; set; }

    public decimal RoomCharge { get; set; }
    public decimal FoodCharge { get; set; }
    public decimal ServiceCharge { get; set; }
    public decimal Tax { get; set; }
    public decimal Discount { get; set; }

    public decimal TotalAmount { get; set; }

    public string Status { get; set; } = "UNPAID";
}