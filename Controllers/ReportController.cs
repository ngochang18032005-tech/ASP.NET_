using Microsoft.AspNetCore.Mvc;
using ASP.Data;
using System.Linq;
using System;

namespace ASP.Controllers;

public class ReportController : Controller
{
    private readonly AppDbContext _context;

    public ReportController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        // Thống kê doanh thu theo 7 ngày gần nhất
        var last7Days = Enumerable.Range(0, 7)
            .Select(i => DateTime.Now.Date.AddDays(-i))
            .Reverse()
            .ToList();

        var revenueData = last7Days.Select(day => 
            _context.Payments
                .Where(p => p.CreatedAt.Date == day)
                .Sum(p => p.Amount)
        ).ToList();

        ViewBag.RevenueLabels = last7Days.Select(d => d.ToString("dd/MM")).ToList();
        ViewBag.RevenueValues = revenueData;

        // Thống kê món ăn (mock logic from seed)
        ViewBag.TopItems = new[] { "Bò Bít Tết Úc", "Salad Cá Ngừ", "Rượu Vang Đỏ", "Cá Hồi Úc" };
        ViewBag.TopValues = new[] { 45, 32, 28, 15 };

        return View();
    }
}
