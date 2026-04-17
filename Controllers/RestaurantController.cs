using Microsoft.AspNetCore.Mvc;

namespace ASP.Controllers;

public class RestaurantController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Menu()
    {
        ViewData["Title"] = "Quản Lý Thực Đơn";
        return View();
    }
}
