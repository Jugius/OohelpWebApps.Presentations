using OohelpWebApps.Presentations.Api.Contracts.Common;

namespace OohelpWebApps.Presentations.Api.Contracts.Responses;

public class PresentationsResponse : Response
{
    public PresentationContract[] Presentations { get; set; }    
}
