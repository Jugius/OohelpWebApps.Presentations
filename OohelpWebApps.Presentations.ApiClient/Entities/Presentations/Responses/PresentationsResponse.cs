using OohelpWebApps.Presentations.ApiClient.Entities.Common;

namespace OohelpWebApps.Presentations.ApiClient.Entities.Presentations.Responses;

public class PresentationsResponse : BaseResponse
{
    public Presentation[] Presentations { get; set; }
}
