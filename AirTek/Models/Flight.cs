namespace AirTek.Models;

public class Flight
{
    public string Origin { get; set; } = "YUL";
    public required string Destination { get; set; }
    public int? Number { get; set; }
    public IList<string> OrdersNumbers { get; set; } = new List<string>();
}