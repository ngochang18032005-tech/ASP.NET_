using ASP.Data;
using ASP.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Controllers.API;

[ApiController]
[Route("api/orders")]
public class OrderController : ControllerBase
{
    private readonly AppDbContext _context;

    public OrderController(AppDbContext context)
    {
        _context = context;
    }

    // Tạo order
    [HttpPost]
    public IActionResult Create(Order model)
    {
        if (model.TableId == null && model.RoomId == null)
            return BadRequest("Order must belong to table or room");

        _context.Orders.Add(model);
        _context.SaveChanges();

        return Ok(model);
    }

    // Thêm món
    [HttpPost("{id}/items")]
    public IActionResult AddItem(int id, OrderDetail item)
    {
        item.OrderId = id;

        _context.OrderDetails.Add(item);
        _context.SaveChanges();

        return Ok(item);
    }

    // Update trạng thái
    [HttpPut("{id}/status")]
    public IActionResult UpdateStatus(int id, string status)
    {
        var order = _context.Orders.Find(id);
        if (order == null) return NotFound();

        order.Status = status;
        _context.SaveChanges();

        return Ok(order);
    }
}