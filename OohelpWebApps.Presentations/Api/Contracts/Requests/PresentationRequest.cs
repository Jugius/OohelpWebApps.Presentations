namespace OohelpWebApps.Presentations.Api.Contracts.Requests;

public class PresentationRequest : BaseRequest
{
    public Common.PresentationContract Presentation { get; set; }
}
