using AirTek.Models;

namespace AirTek
{
    public interface ISchedulerOutput
    {
        string GenerateFlightSchedule(List<Schedule> schedules);
        string GenerateItinerary(List<Schedule> schedules);
    }
}