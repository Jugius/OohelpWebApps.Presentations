using OohelpWebApps.Presentations.ApiClient.Entities.Interfaces;

namespace OohelpWebApps.Presentations.ApiClient.Entities.Presentations.Requests;

public class GetPresentationRequest : BasePresentationRequest, IRequestPost
{
    public override string GetUri() => base.GetUri() + "/byid";
    public Guid Id { get; set; }
}
