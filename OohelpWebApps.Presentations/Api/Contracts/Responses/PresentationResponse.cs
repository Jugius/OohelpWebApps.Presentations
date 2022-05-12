using OohelpWebApps.Presentations.Api.Contracts.Common.Enums;
using OohelpWebApps.Presentations.Domain;

namespace OohelpWebApps.Presentations.Api.Contracts.Responses
{
    public class PresentationResponse : BaseResponse
    {
        public Presentation Presentation { get; set; }        
    }
}
