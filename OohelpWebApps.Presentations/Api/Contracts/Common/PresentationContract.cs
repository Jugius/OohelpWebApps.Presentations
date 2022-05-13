
namespace OohelpWebApps.Presentations.Api.Contracts.Common;

public class PresentationContract
{
    public Guid? Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool ShowOwnerInfo { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string CreatedBy { get; init; }

    public BoardContract[] Boards { get; set; }
}
