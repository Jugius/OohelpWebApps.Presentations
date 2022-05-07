using OohelpWebApps.Presentations.Api.Contracts.Common.Enums;
using OohelpWebApps.Presentations.Domain;

namespace OohelpWebApps.Presentations.Api.Contracts.Responses
{
    public class CreatePresentationResponse
    {
        public Presentation Presentation { get; set; }
        public Status Status { get; set; }
    }
}
