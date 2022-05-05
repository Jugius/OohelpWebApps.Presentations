
namespace OohelpWebApps.Presentations.api.Contracts.Requests;

public class DeletePresentationRequest : Interfaces.IRequest
{
    public Guid Id { get; set; }
    public string Key { get; set; }    
}
