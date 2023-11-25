using AirTek.Data;
using AirTek.Models;
using System.Text;

namespace AirTek
{
    public class SchedulerOutput : ISchedulerOutput
    {
        public string GenerateFlightSchedule(List<Schedule> schedules)
        {
            var builder = new StringBuilder();

            foreach (var schedule in schedules)
            {
                foreach (var flight in schedule.Flights)
                {
                    builder.AppendLine($"Flight: {flight.Number}, departure: {flight.Origin}, arrival: {flight.Destination}, day: {schedule.Day}");
                }
            }

            return builder.ToString().Trim();
        }

        public string GenerateItinerary(List<Schedule> schedules)
        {
            var builder = new StringBuilder();
            var itineraries = new List<ItineraryInfo>();

            foreach (var schedule in schedules)
            {
                foreach (var flight in schedule.Flights)
                {
                    var originAirport = Constants.Airports[flight.Origin];
                    var destinationAirport = Constants.Airports[flight.Destination];
                    var flightNumber = flight.Number.ToString() ?? "not scheduled";

                    foreach (var order in flight.OrdersNumbers)
                    {
                        itineraries.Add(new ItineraryInfo
                        {
                            OrderNumber = order,
                            Info = $"order: {order}, flightNumber: {flightNumber}, departure: {originAirport}, arrival: {destinationAirport}, day: {schedule.Day}"
                        });
                    }
                }
            }

            var itinerariesInfo = itineraries.OrderBy(x => x.OrderNumber).Select(x => x.Info);

            foreach (var item in itinerariesInfo)
            {
                builder.AppendLine(item);
            }

            return builder.ToString().Trim();
        }
    }
}
