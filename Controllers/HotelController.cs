using Microsoft.AspNetCore.Mvc;

namespace ASP.Controllers;

public class HotelController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
