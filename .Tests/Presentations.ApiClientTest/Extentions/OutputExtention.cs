using System.Text.Json;
using System.Text.Json.Serialization;

namespace Presentations.ApiClientTest.Extentions;
public static class OutputExtention
{
    private static readonly JsonSerializerOptions jOptions = new JsonSerializerOptions
    {
        Converters = { new JsonStringEnumConverter() },
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        WriteIndented = true,
    };
    public static void WriteJson(this ITestOutputHelper helper, object? obj)
    {
        string s = JsonSerializer.Serialize(obj, jOptions);
        helper.WriteLine(s);
    }
}
