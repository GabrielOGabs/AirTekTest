using AirTek.Parsers;

namespace AirTek;

public class Program
{
    static void Main(string[] args)
    {
        var path = "data/coding-assigment-orders.json";

        if (args.Any())
        {
            path = args[0];
        }

        if (File.Exists(path))
        {
            try
            {
                string jsonString = File.ReadAllText(path);

                var orders = OrdersFile.Parse(jsonString);
                var scheduler = new Scheduler();
                var schedules = scheduler.ProcessSchedules(orders);
                var output = new SchedulerOutput();

                Console.WriteLine("FLIGHT SCHEDULE");
                Console.Write(output.GenerateFlightSchedule(schedules));

                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("FLIGHT ITINERARY");

                Console.Write(output.GenerateItinerary(schedules));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading the file: " + ex.Message);
            }
        }
        else
        {
            Console.WriteLine("File not found: " + path);
        }

        Console.ReadKey();
    }
}