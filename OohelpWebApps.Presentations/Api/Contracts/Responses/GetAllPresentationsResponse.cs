using OohelpWebApps.Presentations.Api.Contracts.Common.Enums;
using OohelpWebApps.Presentations.Api.Contracts.Common.Interfaces;
using OohelpWebApps.Presentations.Domain;

namespace OohelpWebApps.Presentations.Api.Contracts.Responses;

public class GetAllPresentationsResponse : IResponse
{
    public Presentation[] Presentations { get; set; }
    public Status Status { get; set; }
}
