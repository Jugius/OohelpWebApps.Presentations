using OohelpWebApps.Presentations.ApiClient.Entities.Interfaces;

namespace OohelpWebApps.Presentations.ApiClient.Entities.Presentations.Requests;
public class DeletePresentationRequest : BasePresentationRequest, IRequestDelete
{
    public Guid Id { get; set; }
}
