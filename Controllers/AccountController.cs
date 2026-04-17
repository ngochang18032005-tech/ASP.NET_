using Microsoft.AspNetCore.Mvc;

namespace ASP.Controllers;

public class AccountController : Controller
{
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string email, string password)
    {
        // Simple mock login for demo
        if (email == "admin@luxmanage.com" && password == "admin123")
        {
            return RedirectToAction("Index", "Dashboard");
        }
        
        ViewBag.Error = "Tài khoản hoặc mật khẩu không chính xác!";
        return View();
    }

    public IActionResult Logout()
    {
        return RedirectToAction("Login");
    }
}
