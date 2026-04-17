using Microsoft.AspNetCore.Mvc;
using ASP.Data;
using ASP.Models;
using System.Linq;

namespace ASP.Controllers.API;

[ApiController]
[Route("api/menu")]
public class MenuApiController : ControllerBase
{
    private readonly AppDbContext _context;

    public MenuApiController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_context.MenuItems.ToList());
    }

    [HttpPost]
    public IActionResult Create(MenuItem model)
    {
        _context.MenuItems.Add(model);
        _context.SaveChanges();
        return Ok(model);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var item = _context.MenuItems.Find(id);
        if (item == null) return NotFound();
        _context.MenuItems.Remove(item);
        _context.SaveChanges();
        return Ok();
    }
}
