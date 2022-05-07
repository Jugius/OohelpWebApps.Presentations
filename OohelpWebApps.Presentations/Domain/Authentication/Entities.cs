
namespace OohelpWebApps.Presentations.Domain.Authentication;

public enum Permission
{
    CreateNewPresentation,
    UpdatePresentation,
    DeletePresentation,

    ViewCompanyPresentation,
    UpdateCompanyPresentation,
    DeleteCompanyPresentation,
}
public class Company
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}
public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public Company Company { get; set; }
    public UserKey Key { get; set; }
    public HashSet<Permission> Permissions { get; set; }
    internal bool HasPermission(Permission permission) => Permissions.Contains(permission);
}
public class UserKey
{
    public Guid Id { get; set; }
    public DateTime Created { get; set; }
    public DateTime Expires { get; set; }
}
