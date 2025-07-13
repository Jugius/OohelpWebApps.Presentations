
namespace OohelpWebApps.Presentations.Domain.Entities;
public class Presentation : Common.Entities.BaseAuditableEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsPublic { get; set; }
    public PresentationDesignBoardsListingColumns BoardsListingColumns { get; set; }
    public PresentationDesignBoardCardFields BoardCardFields { get; set; } 
    public List<Board> Boards { get; set; }
    public List<Poi> Pois { get; set; }
}
