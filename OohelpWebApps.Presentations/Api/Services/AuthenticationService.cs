using OohelpWebApps.Presentations.Api.Exceptions;
using OohelpWebApps.Presentations.Api.Services.Helpers;
using OohelpWebApps.Presentations.Domain.Authentication;
using OohelpWebApps.Presentations.Helpers;

namespace OohelpWebApps.Presentations.Api.Services;

public class AuthenticationService
{
    private List<User> Users { get; }
    public AuthenticationService(IConfiguration configuration)
    {
        this.Users = configuration.GetSection("Users").Get<List<User>>();
    }
    public OperationResult<User> Authenticate(string apiKey)
    {
        Guid guidId;
        if (string.IsNullOrEmpty(apiKey) || !Guider.TryToGuidFromString(apiKey, out guidId, out _))
            return new OperationResult<User>(new ApiException(Contracts.Common.Enums.Status.InvalidKey));

        var user = GetUserByKey(guidId);

        if (user == null)
            return new OperationResult<User>(new ApiException(Contracts.Common.Enums.Status.RequestDenied));

        return new OperationResult<User>(user);

    }
    public User GetUserByKey(Guid userKey) => Users.FirstOrDefault(x => x.Key.Id == userKey);
    public User GetUserById(Guid id) => Users.FirstOrDefault(x => x.Id == id);
    public IEnumerable<User> GetUsersByCompanyId(Guid companyId) => Users.Where(a => a?.Company.Id == companyId);

    public bool AllowGetPresentation(User user, Guid ownerId)
    {
        if (user.Id == ownerId) return true;

        User owner = GetUserById(ownerId);

        return AllowGetPresentation(user, owner);
    }
    public bool AllowGetPresentation(User user, User owner)
    {
        if (user?.Company.Id == owner?.Company.Id
                && user.Permissions.Contains(Permission.ViewCompanyPresentation))
            return true;

        return false;
    }

}
