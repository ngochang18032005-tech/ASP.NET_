using ASP.Data;
using ASP.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Controllers.API;

[ApiController]
[Route("api/payments")]
public class PaymentController : ControllerBase
{
    private readonly AppDbContext _context;

    public PaymentController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult Pay(Payment model)
    {
        var invoice = _context.Invoices.Find(model.InvoiceId);
        if (invoice == null) return NotFound();

        invoice.Status = "PAID";

        _context.Payments.Add(model);
        _context.SaveChanges();

        return Ok(model);
    }
}