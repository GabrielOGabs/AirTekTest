using AirTek.Models;
using System.Text.Json;

namespace AirTek.Parsers
{
    public static class OrdersFile
    {
        public static IList<Order> Parse(string jsonString)
        {
            var result = new List<Order>();

            using JsonDocument jsonDocument = JsonDocument.Parse(jsonString);
            JsonElement root = jsonDocument.RootElement;

            foreach (JsonProperty property in root.EnumerateObject())
            {
                var orderNumber = property.Name.ToString();
                var destination = property.Value.GetProperty("destination");

                result.Add(new Order(orderNumber, destination.ToString()));
            }

            return result;
        }
    }
}
