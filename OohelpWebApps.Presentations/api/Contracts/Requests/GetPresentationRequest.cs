
using OohelpWebApps.Presentations.Api.Contracts.Common.Interfaces;

namespace OohelpWebApps.Presentations.Api.Contracts.Requests;

public class GetPresentationRequest : IRequest
{
    public Guid Id { get; set; }
    public string Key { get; set; }
}
