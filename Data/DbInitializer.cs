using ASP.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace ASP.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            // 1. Seed Rooms
            if (!context.Rooms.Any())
            {
                var rooms = new List<Room>();
                string[] statuses = { "Trống", "Có khách", "Đang dọn" };
                Random rnd = new Random();

                for (int i = 1; i <= 30; i++)
                {
                    rooms.Add(new Room
                    {
                        RoomNumber = (100 + i).ToString(),
                        Status = statuses[rnd.Next(statuses.Length)]
                    });
                }
                context.Rooms.AddRange(rooms);
            }

            // 2. Seed Employees
            if (!context.Employees.Any())
            {
                context.Employees.AddRange(
                    new Employee { Name = "Ngọc Hằng", Email = "admin@luxmanage.com", RoleId = 1, CreatedAt = DateTime.Now.AddMonths(-5) },
                    new Employee { Name = "Trần Lê Quân", Email = "quan.tl@luxmanage.com", RoleId = 2, CreatedAt = DateTime.Now.AddMonths(-3) },
                    new Employee { Name = "Lý Thị Bích", Email = "bich.lt@luxmanage.com", RoleId = 3, CreatedAt = DateTime.Now.AddMonths(-2) },
                    new Employee { Name = "Nguyễn Văn Dũng", Email = "dung.nv@luxmanage.com", RoleId = 4, CreatedAt = DateTime.Now.AddMonths(-1) }
                );
            }

            // 3. Seed Menu Items
            if (!context.MenuItems.Any())
            {
                context.MenuItems.AddRange(
                    new MenuItem { Name = "Bò Bít Tết Úc", Price = 650000, Category = "Món Chính", Description = "Bò Wagyu thượng hạng" },
                    new MenuItem { Name = "Cá Hồi Áp Chảo", Price = 450000, Category = "Món Chính", Description = "Cá hồi Na Uy tươi sống" },
                    new MenuItem { Name = "Rượu Vang Đỏ Ly", Price = 300000, Category = "Đồ Uống", Description = "Vang Pháp vùng Bordeaux" },
                    new MenuItem { Name = "Nước Ép Cam", Price = 80000, Category = "Đồ Uống", Description = "Cam sành tươi nguyên chất" },
                    new MenuItem { Name = "Salad Hoàng Đế", Price = 180000, Category = "Khai Vị", Description = "Salad rau củ hữu cơ" }
                );
                context.SaveChanges();
            }

            // 4. Seed Orders & Payments (for Charts)
            if (!context.Orders.Any())
            {
                Random rnd = new Random();
                var menuIds = context.MenuItems.Select(m => m.Id).ToList();
                for (int i = 1; i <= 30; i++)
                {
                    var order = new Order
                    {
                        TableId = rnd.Next(1, 9),
                        Status = i % 8 == 0 ? "OPEN" : "PAID"
                    };
                    context.Orders.Add(order);
                    context.SaveChanges();

                    context.OrderDetails.Add(new OrderDetail { 
                        OrderId = order.Id, 
                        MenuId = menuIds[rnd.Next(menuIds.Count)], 
                        Quantity = rnd.Next(1, 3) 
                    });
                    
                    if (order.Status == "PAID")
                    {
                        context.Payments.Add(new Payment
                        {
                            OrderId = order.Id,
                            Amount = rnd.Next(500000, 2000000),
                            CreatedAt = DateTime.Now.AddDays(-rnd.Next(0, 30)),
                            Method = "Cash"
                        });
                    }
                }
            }

            // 5. Seed Initial Bookings
            if (!context.Bookings.Any())
            {
                context.Bookings.Add(new Booking {
                    RoomId = 1,
                    CustomerName = "Nguyễn Văn A",
                    CustomerPhone = "0987654321",
                    CheckIn = DateTime.Now.AddDays(-1),
                    CheckOut = DateTime.Now.AddDays(2),
                    Status = "PENDING"
                });
            }

            context.SaveChanges();
        }
    }
}
