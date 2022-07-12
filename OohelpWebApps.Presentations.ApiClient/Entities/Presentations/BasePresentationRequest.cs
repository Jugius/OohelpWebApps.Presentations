using OohelpWebApps.Presentations.ApiClient.Entities.Interfaces;

namespace OohelpWebApps.Presentations.ApiClient.Entities.Presentations;

public abstract class BasePresentationRequest : IRequest
{
    public string Key { get; set; }

    public virtual string GetUri() => "api/presentations";
}
