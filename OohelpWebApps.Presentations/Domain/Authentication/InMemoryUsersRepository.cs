using OohelpWebApps.Presentations.Api.Exceptions;

namespace OohelpWebApps.Presentations.Domain.Authentication;

public class InMemoryUsersRepository
{
    private static readonly List<Company> companies = new List<Company>
    {
        new Company { Id = new Guid("5d86c1a0-583c-410f-ba77-b521377be19a"), Name = "AdStrategy" },
        new Company { Id = new Guid("f02fec12-53be-49f8-ba97-197565900b1b"), Name = "Бигмедиа" },
    };


    private static List<User> _mockUsers;
    private static List<User> Users = _mockUsers ??= new List<User>
    {
        new User {
            Id = new Guid("d8e36bb7-777b-4b5b-a36c-6ed71f0bb9d4"),
            Company = companies[0],
            Username = "andrey.slusarev", Password = "admin",
            Permissions = Enum.GetValues(typeof(Permission)).Cast<Permission>().ToHashSet(),
            Key = new UserKey{ Id = new Guid("5c9a3035-3cbc-4961-a59b-73b2c52865ed"), Created = DateTime.Now, Expires = DateTime.Today }
        },
        new User {
            Id = new Guid("a8703d4a-d2f8-45d1-98a5-17a2dabcf809"),
            Company = companies[1],
            Username = "ilya.kiselov", Password = "qwerty",
            Permissions = Enum.GetValues(typeof(Permission)).Cast<Permission>().ToHashSet(),
            Key = new UserKey{ Id = new Guid("4025992d-db72-4df5-b4b2-7c1a7c27bf55"), Created = DateTime.Now, Expires = DateTime.Today }
        },
        new User {
            Id = new Guid("a0db9f7a-711a-49fc-aaff-477be95abdcb"),
            Company = companies[0],
            Username = "natali.sharipova", Password = "natali",
            Permissions = Enum.GetValues(typeof(Permission)).Cast<Permission>().ToHashSet(),
            Key = new UserKey{ Id = new Guid("c1825b6f-2a5b-41f8-8c6e-272b6fdc1566"), Created = DateTime.Now, Expires = DateTime.Today }
        }
    };

    public User GetUserByKey(Guid userKey) => Users.FirstOrDefault(x => x.Key.Id == userKey);    
    public User GetUserById(Guid id) => Users.FirstOrDefault(x => x.Id == id);
    public User Authenticate(string apiKey)
    {
        Guid guidId;
        if (string.IsNullOrEmpty(apiKey) || !Helpers.Guider.TryToGuidFromString(apiKey, out guidId, out _))
            throw new ApiException(Api.Contracts.Common.Enums.Status.InvalidRequest);
        
        return GetUserByKey(guidId);        
    }
}
