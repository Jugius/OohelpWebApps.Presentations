using OohelpWebApps.Presentations.Api.Exceptions;

namespace OohelpWebApps.Presentations.Domain.Authentication;

public class InMemoryUsersRepository
{
    public User GetUserByKey(Guid userKey) => AppConfig.Users.FirstOrDefault(x => x.Key.Id == userKey);
    public User GetUserById(Guid id) =>AppConfig.Users.FirstOrDefault(x => x.Id == id);
    public User Authenticate(string apiKey)
    {
        Guid guidId;
        if (string.IsNullOrEmpty(apiKey) || !Helpers.Guider.TryToGuidFromString(apiKey, out guidId, out _))
            throw new ApiException(Api.Contracts.Common.Enums.Status.InvalidRequest);
        
        return GetUserByKey(guidId);        
    }    
}
