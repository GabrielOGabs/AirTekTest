using AirTek.Models;

namespace AirTek;

public class Scheduler : IScheduler
{
    private const int MAX_FLIGHT_CAPACITY = 20;
    private static readonly string[] ALLOWED_DESTINATIONS = { "YYZ", "YYC", "YVR" };

    public List<Schedule> ProcessSchedules(IEnumerable<Order> data)
    {
        var currentFlightPlannings = new Dictionary<string, Flight>();
        var destinationBookedFlights = new Dictionary<string, List<Flight>>();

        foreach (var order in data)
        {
            if (!ALLOWED_DESTINATIONS.Contains(order.Destination)) continue;

            var currentFlight = GetCurrentFlightPlanning(currentFlightPlannings, order.Destination);

            currentFlight.OrdersNumbers.Add(order.Number);
            if (currentFlight.OrdersNumbers.Count == MAX_FLIGHT_CAPACITY)
            {
                BookFlight(destinationBookedFlights, order.Destination, currentFlight);
                currentFlightPlannings.Remove(order.Destination);
            }
        }

        foreach (var remainingFlight in currentFlightPlannings)
        {
            BookFlight(destinationBookedFlights, remainingFlight.Key, remainingFlight.Value);
        }

        var schedules = ScheduleFlights(destinationBookedFlights);

        return schedules;
    }

    private static List<Schedule> ScheduleFlights(Dictionary<string, List<Flight>> destinationBookedFlights)
    {
        var schedules = new List<Schedule>();
        var day = 1;
        var flightNumber = 1;

        while (destinationBookedFlights.Any())
        {
            var schedule = new Schedule(day++);

            foreach (var destination in destinationBookedFlights)
            {
                var flight = destination.Value.First();
                flight.Number = flightNumber++;
                schedule.Flights.Add(flight);
                destination.Value.RemoveAt(0);

                if (!destination.Value.Any())
                {
                    destinationBookedFlights.Remove(destination.Key);
                }
            }

            schedules.Add(schedule);
        }

        return schedules;
    }

    private static Flight GetCurrentFlightPlanning(Dictionary<string, Flight> currentFlights, string destination)
    {
        if (!currentFlights.ContainsKey(destination))
        {
            currentFlights.Add(destination, new Flight()
            {
                Destination = destination
            });
        }

        return currentFlights[destination];
    }

    private static void BookFlight(Dictionary<string, List<Flight>> flights, string key, Flight flight)
    {
        if (!flights.ContainsKey(key))
        {
            flights.Add(key, new());
        }

        flights[key].Add(flight);
    }
}