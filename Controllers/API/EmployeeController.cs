using ASP.Data;
using ASP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ASP.Controllers.API;

[ApiController]
[Route("api/employees")]
public class EmployeeController : ControllerBase
{
    private readonly AppDbContext _context;

    public EmployeeController(AppDbContext context)
    {
        _context = context;
    }

    // GET
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_context.Employees.ToList());
    }

    // POST
    [HttpPost]
    public IActionResult Create(Employee model)
    {
        _context.Employees.Add(model);
        _context.SaveChanges();
        return Ok(model);
    }

    // PUT
    [HttpPut("{id}")]
    public IActionResult Update(int id, Employee model)
    {
        var emp = _context.Employees.Find(id);
        if (emp == null) return NotFound();

        emp.Name = model.Name;
        emp.Email = model.Email;
        emp.RoleId = model.RoleId;

        _context.SaveChanges();
        return Ok(emp);
    }

    // DELETE
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var emp = _context.Employees.Find(id);
        if (emp == null) return NotFound();

        _context.Employees.Remove(emp);
        _context.SaveChanges();

        return Ok();
    }
}