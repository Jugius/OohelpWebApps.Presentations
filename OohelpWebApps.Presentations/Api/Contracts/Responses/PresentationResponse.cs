using OohelpWebApps.Presentations.Api.Contracts.Common;

namespace OohelpWebApps.Presentations.Api.Contracts.Responses
{
    public class PresentationResponse : Response
    {
        public PresentationContract Presentation { get; set; }        
    }
}
