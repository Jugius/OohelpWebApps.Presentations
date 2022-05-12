namespace OohelpWebApps.Presentations.Api.Contracts.Requests;

public class UpdatePresentationRequest : BaseRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool ShowOwner { get; set; }
}
