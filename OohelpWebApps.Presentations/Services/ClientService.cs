using OohelpWebApps.Presentations.Api.ClientService;
using OohelpWebApps.Presentations.Models;

namespace OohelpWebApps.Presentations.Services;

public class ClientService
{
    private static readonly List<Company> companies = new List<Company>
    {
        new Company{ Id = new Guid("5d86c1a0-583c-410f-ba77-b521377be19a"), Name = "AdStrategy" },
    };
    private static List<User> _mockUsers;
    private static List<User> Users = _mockUsers ??= new List<User>
    {
        new User {
            Id = new Guid("d8e36bb7-777b-4b5b-a36c-6ed71f0bb9d4"),
            Company = companies[0],
            FirstName = "Andrey", SecondName = "Slusarev",
            Email = "a.slusarev@light-c.com.ua",
            Login = "admin", Password = "admin",
            PhoneNumber = "+1234567890",
            Permissions = Enum.GetValues(typeof(Permission)).Cast<Permission>().ToHashSet(),
            Key = new UserKey{ Id = new Guid("5c9a3035-3cbc-4961-a59b-73b2c52865ed"), Created = DateTime.Now, Expires = DateTime.Today }
        }
    };

    public User GetByKey (Guid userKey) => Users.FirstOrDefault(x => x.Key.Id == userKey);

    public async Task<ClientInfoViewModel> GetClientInfo(Guid Id)
    {
        return await Task.FromResult(new Models.ClientInfoViewModel { Name = "Ad Strategy", Logo = "Logo_w150.png" });
    }
}
