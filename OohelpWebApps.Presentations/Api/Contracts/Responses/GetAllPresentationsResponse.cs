using OohelpWebApps.Presentations.Domain;

namespace OohelpWebApps.Presentations.Api.Contracts.Responses;

public class GetAllPresentationsResponse : BaseResponse
{
    public Presentation[] Presentations { get; set; }    
}
