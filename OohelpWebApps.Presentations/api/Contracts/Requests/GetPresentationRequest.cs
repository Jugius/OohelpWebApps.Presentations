
namespace OohelpWebApps.Presentations.api.Contracts.Requests;

public class GetPresentationRequest : Interfaces.IRequest
{
    public Guid Id { get; set; }
    public string Key { get; set; }
}
