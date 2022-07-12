namespace OohelpWebApps.Presentations.Api.Contracts.Requests;

public class UpdatePresentationRequest : CreatePresentationRequest
{
    public Guid Id { get; set; }
}
