
using OohelpWebApps.Presentations.Domain.Authentication;

namespace OohelpWebApps.Presentations;

public class AppConfig
{
    public static string ConnectionString { get; set; }
    public static System.Guid AdminKey { get; set; }
    public static List<User> Users { get; set; }
}
