using OohelpWebApps.Presentations.Domain;

namespace OohelpWebApps.Presentations.api.Contracts.Requests;

public class CreatePresentationRequest : Interfaces.IRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool ShowOwner { get; set; }
    public List<Board> Boards { get; set; }

    public string Key { get; set; }
}
