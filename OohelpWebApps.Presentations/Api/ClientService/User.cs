namespace OohelpWebApps.Presentations.Api.ClientService;

public class User
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public Company Company { get; set; }    
    public string Login { get; set; }
    public string Password { get; set; }
    public UserKey Key { get; set; }
    public HashSet<Permission> Permissions { get; set; }
}
