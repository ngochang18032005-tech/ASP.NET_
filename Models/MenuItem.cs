namespace ASP.Models;

public class MenuItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; } // Món chính, Đồ uống, Tráng miệng
    public string Description { get; set; }
}
