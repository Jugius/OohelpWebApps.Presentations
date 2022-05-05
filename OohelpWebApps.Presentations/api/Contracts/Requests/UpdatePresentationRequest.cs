using OohelpWebApps.Presentations.Api.Contracts.Common.Interfaces;
using OohelpWebApps.Presentations.Domain;

namespace OohelpWebApps.Presentations.Api.Contracts.Requests;

public class UpdatePresentationRequest : IRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool ShowOwner { get; set; }
    public List<Board> Boards { get; set; }

    public string Key { get; set; }
}
