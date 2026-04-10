using System;

namespace ASP.Models;

public class Payment
{
    public int Id { get; set; }
    public int InvoiceId { get; set; }

    public decimal Amount { get; set; }

    public string Method { get; set; } = "CASH"; // CASH, CARD

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}