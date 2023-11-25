using AirTek.Models;

namespace AirTek
{
    public interface IScheduler
    {
        List<Schedule> ProcessSchedules(IEnumerable<Order> data);
    }
}