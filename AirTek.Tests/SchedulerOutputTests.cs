using AirTek.Models;
using System.Text.Json;

namespace AirTek.Tests;

public class SchedulerOutputTests
{
    [Fact]
    public void Case1_Should_Output_FlightSchedule_Successfully()
    {
        string jsonString = File.ReadAllText("TestFiles/case1.json");

        var schedules = JsonSerializer.Deserialize<List<Schedule>>(jsonString)!;

        var schedulerOutput = new SchedulerOutput();

        var output = schedulerOutput.GenerateFlightSchedule(schedules);

        var expectedOutput = """
            Flight: 1, departure: YUL, arrival: YYZ, day: 1
            Flight: 2, departure: YUL, arrival: YYC, day: 1
            Flight: 3, departure: YUL, arrival: YVR, day: 1
            Flight: 4, departure: YUL, arrival: YYZ, day: 2
            Flight: 5, departure: YUL, arrival: YYC, day: 2
            Flight: 6, departure: YUL, arrival: YVR, day: 2
            """;

        Assert.NotNull(output);
        Assert.Equal(expectedOutput, output);
    }

    [Fact]
    public void Should_Output_FlightItinerary_Successfully()
    {
        string jsonString = File.ReadAllText("TestFiles/case1.json");

        var schedules = JsonSerializer.Deserialize<List<Schedule>>(jsonString)!;

        var schedulerOutput = new SchedulerOutput();

        var output = schedulerOutput.GenerateItinerary(schedules);

        var expectedOutput = """
            order: order-001, flightNumber: 1, departure: Montreal, arrival: Toronto, day: 1
            order: order-002, flightNumber: 1, departure: Montreal, arrival: Toronto, day: 1
            order: order-003, flightNumber: 1, departure: Montreal, arrival: Toronto, day: 1
            order: order-004, flightNumber: 1, departure: Montreal, arrival: Toronto, day: 1
            order: order-005, flightNumber: 1, departure: Montreal, arrival: Toronto, day: 1
            order: order-006, flightNumber: 1, departure: Montreal, arrival: Toronto, day: 1
            order: order-007, flightNumber: 1, departure: Montreal, arrival: Toronto, day: 1
            order: order-008, flightNumber: 1, departure: Montreal, arrival: Toronto, day: 1
            order: order-009, flightNumber: 1, departure: Montreal, arrival: Toronto, day: 1
            order: order-010, flightNumber: 1, departure: Montreal, arrival: Toronto, day: 1
            order: order-011, flightNumber: 1, departure: Montreal, arrival: Toronto, day: 1
            order: order-012, flightNumber: 1, departure: Montreal, arrival: Toronto, day: 1
            order: order-013, flightNumber: 1, departure: Montreal, arrival: Toronto, day: 1
            order: order-014, flightNumber: 1, departure: Montreal, arrival: Toronto, day: 1
            order: order-015, flightNumber: 1, departure: Montreal, arrival: Toronto, day: 1
            order: order-016, flightNumber: 1, departure: Montreal, arrival: Toronto, day: 1
            order: order-017, flightNumber: 1, departure: Montreal, arrival: Toronto, day: 1
            order: order-018, flightNumber: 1, departure: Montreal, arrival: Toronto, day: 1
            order: order-019, flightNumber: 1, departure: Montreal, arrival: Toronto, day: 1
            order: order-020, flightNumber: 1, departure: Montreal, arrival: Toronto, day: 1
            order: order-021, flightNumber: 4, departure: Montreal, arrival: Toronto, day: 2
            order: order-022, flightNumber: 4, departure: Montreal, arrival: Toronto, day: 2
            order: order-023, flightNumber: 4, departure: Montreal, arrival: Toronto, day: 2
            order: order-024, flightNumber: 4, departure: Montreal, arrival: Toronto, day: 2
            order: order-025, flightNumber: 4, departure: Montreal, arrival: Toronto, day: 2
            order: order-026, flightNumber: 4, departure: Montreal, arrival: Toronto, day: 2
            order: order-027, flightNumber: 4, departure: Montreal, arrival: Toronto, day: 2
            order: order-028, flightNumber: 4, departure: Montreal, arrival: Toronto, day: 2
            order: order-029, flightNumber: 4, departure: Montreal, arrival: Toronto, day: 2
            order: order-030, flightNumber: 4, departure: Montreal, arrival: Toronto, day: 2
            order: order-031, flightNumber: 4, departure: Montreal, arrival: Toronto, day: 2
            order: order-032, flightNumber: 4, departure: Montreal, arrival: Toronto, day: 2
            order: order-033, flightNumber: 4, departure: Montreal, arrival: Toronto, day: 2
            order: order-034, flightNumber: 4, departure: Montreal, arrival: Toronto, day: 2
            order: order-035, flightNumber: 2, departure: Montreal, arrival: Calgary, day: 1
            order: order-036, flightNumber: 2, departure: Montreal, arrival: Calgary, day: 1
            order: order-037, flightNumber: 2, departure: Montreal, arrival: Calgary, day: 1
            order: order-038, flightNumber: 2, departure: Montreal, arrival: Calgary, day: 1
            order: order-039, flightNumber: 2, departure: Montreal, arrival: Calgary, day: 1
            order: order-040, flightNumber: 2, departure: Montreal, arrival: Calgary, day: 1
            order: order-041, flightNumber: 2, departure: Montreal, arrival: Calgary, day: 1
            order: order-042, flightNumber: 2, departure: Montreal, arrival: Calgary, day: 1
            order: order-043, flightNumber: 2, departure: Montreal, arrival: Calgary, day: 1
            order: order-044, flightNumber: 2, departure: Montreal, arrival: Calgary, day: 1
            order: order-045, flightNumber: 2, departure: Montreal, arrival: Calgary, day: 1
            order: order-046, flightNumber: 2, departure: Montreal, arrival: Calgary, day: 1
            order: order-047, flightNumber: 2, departure: Montreal, arrival: Calgary, day: 1
            order: order-048, flightNumber: 2, departure: Montreal, arrival: Calgary, day: 1
            order: order-050, flightNumber: 2, departure: Montreal, arrival: Calgary, day: 1
            order: order-052, flightNumber: 2, departure: Montreal, arrival: Calgary, day: 1
            order: order-054, flightNumber: 2, departure: Montreal, arrival: Calgary, day: 1
            order: order-055, flightNumber: 2, departure: Montreal, arrival: Calgary, day: 1
            order: order-056, flightNumber: 2, departure: Montreal, arrival: Calgary, day: 1
            order: order-057, flightNumber: 2, departure: Montreal, arrival: Calgary, day: 1
            order: order-060, flightNumber: 5, departure: Montreal, arrival: Calgary, day: 2
            order: order-061, flightNumber: 5, departure: Montreal, arrival: Calgary, day: 2
            order: order-062, flightNumber: 3, departure: Montreal, arrival: Vancouver, day: 1
            order: order-063, flightNumber: 3, departure: Montreal, arrival: Vancouver, day: 1
            order: order-064, flightNumber: 3, departure: Montreal, arrival: Vancouver, day: 1
            order: order-065, flightNumber: 3, departure: Montreal, arrival: Vancouver, day: 1
            order: order-066, flightNumber: 3, departure: Montreal, arrival: Vancouver, day: 1
            order: order-067, flightNumber: 3, departure: Montreal, arrival: Vancouver, day: 1
            order: order-068, flightNumber: 3, departure: Montreal, arrival: Vancouver, day: 1
            order: order-069, flightNumber: 3, departure: Montreal, arrival: Vancouver, day: 1
            order: order-070, flightNumber: 3, departure: Montreal, arrival: Vancouver, day: 1
            order: order-071, flightNumber: 3, departure: Montreal, arrival: Vancouver, day: 1
            order: order-072, flightNumber: 3, departure: Montreal, arrival: Vancouver, day: 1
            order: order-073, flightNumber: 3, departure: Montreal, arrival: Vancouver, day: 1
            order: order-074, flightNumber: 3, departure: Montreal, arrival: Vancouver, day: 1
            order: order-075, flightNumber: 3, departure: Montreal, arrival: Vancouver, day: 1
            order: order-076, flightNumber: 3, departure: Montreal, arrival: Vancouver, day: 1
            order: order-077, flightNumber: 3, departure: Montreal, arrival: Vancouver, day: 1
            order: order-078, flightNumber: 3, departure: Montreal, arrival: Vancouver, day: 1
            order: order-080, flightNumber: 3, departure: Montreal, arrival: Vancouver, day: 1
            order: order-081, flightNumber: 3, departure: Montreal, arrival: Vancouver, day: 1
            order: order-082, flightNumber: 3, departure: Montreal, arrival: Vancouver, day: 1
            order: order-083, flightNumber: 6, departure: Montreal, arrival: Vancouver, day: 2
            order: order-084, flightNumber: 6, departure: Montreal, arrival: Vancouver, day: 2
            order: order-085, flightNumber: 6, departure: Montreal, arrival: Vancouver, day: 2
            order: order-086, flightNumber: 6, departure: Montreal, arrival: Vancouver, day: 2
            order: order-087, flightNumber: 6, departure: Montreal, arrival: Vancouver, day: 2
            order: order-088, flightNumber: 6, departure: Montreal, arrival: Vancouver, day: 2
            order: order-089, flightNumber: 6, departure: Montreal, arrival: Vancouver, day: 2
            order: order-090, flightNumber: 6, departure: Montreal, arrival: Vancouver, day: 2
            order: order-091, flightNumber: 6, departure: Montreal, arrival: Vancouver, day: 2
            order: order-092, flightNumber: 6, departure: Montreal, arrival: Vancouver, day: 2
            order: order-093, flightNumber: 6, departure: Montreal, arrival: Vancouver, day: 2
            order: order-094, flightNumber: 6, departure: Montreal, arrival: Vancouver, day: 2
            order: order-095, flightNumber: 6, departure: Montreal, arrival: Vancouver, day: 2
            order: order-096, flightNumber: 6, departure: Montreal, arrival: Vancouver, day: 2
            order: order-097, flightNumber: 6, departure: Montreal, arrival: Vancouver, day: 2
            order: order-098, flightNumber: 6, departure: Montreal, arrival: Vancouver, day: 2
            order: order-099, flightNumber: 6, departure: Montreal, arrival: Vancouver, day: 2
            """;

        Assert.NotNull(output);
        Assert.Equal(expectedOutput, output);
    }
}
