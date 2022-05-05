
using OohelpWebApps.Presentations.Api.Contracts.Common.Interfaces;

namespace OohelpWebApps.Presentations.Api.Contracts.Requests;

public class DeletePresentationRequest : IRequest
{
    public Guid Id { get; set; }
    public string Key { get; set; }    
}
