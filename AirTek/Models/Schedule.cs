namespace AirTek.Models;

public class Schedule
{
    public int Day { get; set; }
    public IList<Flight> Flights { get; set; }

    public Schedule(int day)
        :this()
    {
        Day = day;
    }

    public Schedule()
    {
        Flights = new List<Flight>();
    }
}
