
namespace OohelpWebApps.Presentations.Domain;

public class Presentation
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Board> Boards { get; set; }
}
