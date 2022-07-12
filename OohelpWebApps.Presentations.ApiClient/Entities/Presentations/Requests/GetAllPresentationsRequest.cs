using OohelpWebApps.Presentations.ApiClient.Entities.Interfaces;

namespace OohelpWebApps.Presentations.ApiClient.Entities.Presentations.Requests;

public sealed class GetAllPresentationsRequest : BasePresentationRequest, IRequestPost
{
    public override string GetUri() => base.GetUri() + "/getall";
    public bool ShowAllAvailable { get; set; }
}