using Microsoft.AspNetCore.Mvc;
using ASP.Data;
using System.Linq;

namespace ASP.Controllers;

public class DashboardController : Controller
{
    private readonly AppDbContext _context;

    public DashboardController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        // Tính doanh thu từ bảng Payments
        var revenue = _context.Payments.Sum(p => p.Amount);
        ViewBag.TotalRevenue = revenue.ToString("N0") + "đ";

        // Đếm phòng trống
        ViewBag.AvailableRooms = _context.Rooms.Count(r => r.Status == "Trống" || r.Status == "Available");

        // Đếm bàn đang mở
        ViewBag.ActiveTables = _context.Orders.Count(o => o.Status == "OPEN" && o.TableId != null);

        // Đếm yêu cầu dịch vụ (VD là danh sách booking mới chưa checkin)
        ViewBag.PendingOrders = _context.Bookings.Count(b => b.Status == "CONFIRMED");

        return View();
    }
}
