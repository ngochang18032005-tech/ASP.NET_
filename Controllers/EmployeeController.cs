using Microsoft.AspNetCore.Mvc;

namespace ASP.Controllers;

public class EmployeeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
