using OohelpWebApps.Presentations.Domain.Common.Entities;
using OohelpWebApps.Presentations.Domain.Enums;

namespace OohelpWebApps.Presentations.Domain.Entities;
public class Poi : BaseEntity
{    
    public string Name { get; set; }
    public string Description { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string IconColor { get; set; }
    public IconStyle IconStyle { get; set; }

    public Guid PresentationId { get; set; }
}
