using AirTek.Models;
using AirTek.Parsers;
using System.Text.Json;

namespace AirTek.Tests;

public class SchedulerTests
{
    [Fact]
    public void Should_Schedule_Successfully()
    {
        var orders = new List<Order>()
        {
            new Order("order-001", "YYZ"),
            new Order("order-002", "YYZ"),
            new Order("order-003", "YYZ"),
            new Order("order-004", "YYC"),
            new Order("order-005", "YYC"),
            new Order("order-006", "YVR")
        };

        var scheduler = new Scheduler();
        var schedules = scheduler.ProcessSchedules(orders);

        Assert.NotNull(schedules);
        Assert.Single(schedules);
        Assert.Equal(1, schedules[0].Day);
    }

    [Fact]
    public void Should_Schedule_Multiple_Successfully()
    {
        var orders = new List<Order>()
        {
            new Order("order-001", "YYZ"),
            new Order("order-002", "YYZ"),
            new Order("order-003", "YYZ"),
            new Order("order-004", "YYC"),
            new Order("order-005", "YYC"),
            new Order("order-006", "YVR"),
            new Order("order-007", "YYZ"),
            new Order("order-008", "YYZ"),
            new Order("order-009", "YYZ"),
            new Order("order-010", "YYC"),
            new Order("order-011", "YYC"),
            new Order("order-012", "YVR"),
            new Order("order-013", "YYZ"),
            new Order("order-014", "YYZ"),
            new Order("order-015", "YYZ"),
            new Order("order-016", "YYC"),
            new Order("order-017", "YYC"),
            new Order("order-018", "YVR"),
            new Order("order-019", "YYZ"),
            new Order("order-020", "YYZ"),
            new Order("order-021", "YYZ"),
            new Order("order-022", "YYC"),
            new Order("order-023", "YYC"),
            new Order("order-024", "YVR"),
            new Order("order-025", "YYZ"),
            new Order("order-026", "YYZ"),
            new Order("order-027", "YYZ"),
            new Order("order-028", "YYC"),
            new Order("order-029", "YYC"),
            new Order("order-030", "YVR"),
            new Order("order-031", "YYZ"),
            new Order("order-032", "YYZ"),
            new Order("order-033", "YYZ"),
            new Order("order-034", "YYC"),
            new Order("order-035", "YYC"),
            new Order("order-036", "YVR"),
            new Order("order-037", "YYZ"),
            new Order("order-038", "YYZ"),
            new Order("order-039", "YYZ"),
            new Order("order-040", "YYC"),
            new Order("order-041", "YYC"),
            new Order("order-042", "YVR"),
            new Order("order-043", "YYZ"),
            new Order("order-044", "YYZ"),
            new Order("order-045", "YYZ"),
            new Order("order-046", "YYC"),
            new Order("order-047", "YYC"),
            new Order("order-048", "YVR"),
            new Order("order-049", "YYZ"),
            new Order("order-051", "YYZ"),
            new Order("order-052", "YYZ"),
            new Order("order-053", "YYC"),
            new Order("order-054", "YYC"),
            new Order("order-055", "YVR"),
        };

        var scheduler = new Scheduler();
        var schedules = scheduler.ProcessSchedules(orders);

        Assert.NotNull(schedules);
        Assert.Equal(2, schedules.Count);
        Assert.Equal(1, schedules[0].Day);
        Assert.Equal(2, schedules[1].Day);
    }

    [Fact]
    public void Should_Schedule_Multiple_Successfully_order1()
    {
        string jsonString = File.ReadAllText("TestFiles/orders1.json");
        var orders = JsonSerializer.Deserialize<List<Order>>(jsonString)!;

        var scheduler = new Scheduler();
        var schedules = scheduler.ProcessSchedules(orders);

        Assert.NotNull(schedules);
        Assert.Equal(5, schedules.Count);
    }
}
