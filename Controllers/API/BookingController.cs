using ASP.Data;
using ASP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ASP.Controllers.API;

[ApiController]
[Route("api/bookings")]
public class BookingController : ControllerBase
{
    private readonly AppDbContext _context;

    public BookingController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/bookings
    [HttpGet]
    public IActionResult GetAll()
    {
        var data = _context.Bookings
            .Select(b => new {
                b.Id,
                b.RoomId,
                b.CheckIn,
                b.CheckOut,
                b.Status
            }).ToList();

        return Ok(data);
    }

    // POST: api/bookings
    [HttpPost]
    public IActionResult Create(Booking model)
    {
        bool isAvailable = !_context.Bookings.Any(b =>
            b.RoomId == model.RoomId &&
            (model.CheckIn < b.CheckOut && model.CheckOut > b.CheckIn)
        );

        if (!isAvailable)
            return Conflict("Room already booked");

        _context.Bookings.Add(model);
        _context.SaveChanges();

        return Ok(model);
    }

    // PUT: api/bookings/{id}/checkin
    [HttpPut("{id}/checkin")]
    public IActionResult CheckIn(int id)
    {
        var booking = _context.Bookings.Find(id);
        if (booking == null) return NotFound();

        booking.Status = "CHECKED_IN";
        _context.SaveChanges();

        return Ok();
    }

    // PUT: api/bookings/{id}/checkout
    [HttpPut("{id}/checkout")]
    public IActionResult CheckOut(int id)
    {
        var booking = _context.Bookings.Find(id);
        if (booking == null) return NotFound();

        booking.Status = "CHECKED_OUT";
        _context.SaveChanges();

        return Ok();
    }
}