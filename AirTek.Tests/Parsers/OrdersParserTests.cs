using AirTek.Parsers;
using AirTek.Models;

namespace AirTek.Tests.Parsers;

public class OrdersParserTests
{
    [Fact]
    public void Should_Parse_Successfully()
    {
        var validJson = """
            {
                "order-001": {
                    "destination" : "YYZ"
                },"order-002": {
                    "destination" : "YYZ"
                },"order-003": {
                    "destination" : "YYZ"
                },"order-004": {
                    "destination" : "YYZ"
                },"order-005": {
                    "destination" : "YYZ"
                }
            }
            """;

        var orders = OrdersFile.Parse(validJson);

        var expectedResults = new List<Order>
        {
            new Order("order-001", "YYZ"),
            new Order("order-002", "YYZ"),
            new Order("order-003", "YYZ"),
            new Order("order-004", "YYZ"),
            new Order("order-005", "YYZ"),
        };

        Assert.NotNull(orders);
        Assert.True(orders.Count == 5);
        Assert.Equal(expectedResults, orders);
    }

    [Fact]
    public void Should_Throw_Exception()
    {
        var invalidJson = """
            {
                "order-001": {}
            }
            """;

        Assert.Throws<KeyNotFoundException>(() =>
        {
            _ = OrdersFile.Parse(invalidJson);
        });
    }
}
