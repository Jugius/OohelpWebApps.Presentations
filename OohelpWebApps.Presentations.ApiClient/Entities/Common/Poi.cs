using OohelpWebApps.Presentations.ApiClient.Entities.Common.Enums;

namespace OohelpWebApps.Presentations.ApiClient.Entities.Common;

public class Poi
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string IconColor { get; set; }
    public IconStyle IconStyle { get; set; }
    public Guid PresentationId { get; set; }
}
