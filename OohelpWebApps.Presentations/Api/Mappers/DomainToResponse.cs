using OohelpWebApps.Presentations.Api.Contracts.Responses;
using OohelpWebApps.Presentations.Domain;

namespace OohelpWebApps.Presentations.Api.Mappers;
public static class DomainToResponse
{
    public static PresentationResponse ToResponse(this Presentation presentation) =>
        new PresentationResponse
        {
            Status = Contracts.Common.Enums.Status.Ok,
            Presentation = presentation.ToContract()
        };

    public static PresentationsResponse ToResponse(this IEnumerable<Presentation> presentations) =>
        new PresentationsResponse
        {
            Status = Contracts.Common.Enums.Status.Ok,
            Presentations = presentations.Select(a => a.ToContract()).ToArray()
        };
}
