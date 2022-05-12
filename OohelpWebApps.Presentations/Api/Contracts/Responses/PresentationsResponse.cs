using OohelpWebApps.Presentations.Domain;

namespace OohelpWebApps.Presentations.Api.Contracts.Responses;

public class PresentationsResponse : BaseResponse
{
    public Presentation[] Presentations { get; set; }    
}
