using OohelpWebApps.Presentations.Domain.Common.Entities;

namespace OohelpWebApps.Presentations.Domain.Entities;
public class PresentationDesignBoardCardFields : BaseEntity
{
    public bool Type { get; set; }
    public bool Side { get; set; }
    public bool Price { get; set; }
    public bool Media { get; set; }
    public bool Supplier { get; set; }
    public bool Code { get; set; }
}
