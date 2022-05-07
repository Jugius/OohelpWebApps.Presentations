using OohelpWebApps.Presentations.Api.Contracts.Common.Interfaces;

namespace OohelpWebApps.Presentations.Api.Contracts.Requests;

public class GetAllPresentationsRequest : IRequest
{
    public string Key { get; set; }
    public bool ShowAllAvailable { get; set; }
}
