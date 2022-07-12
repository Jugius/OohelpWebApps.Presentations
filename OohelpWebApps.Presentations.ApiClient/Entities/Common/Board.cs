using OohelpWebApps.Presentations.ApiClient.Entities.Common.Enums;

namespace OohelpWebApps.Presentations.ApiClient.Entities.Common;

public class Board
{
    public Guid Id { get; set; }
    public string Supplier { get; set; }
    public string Code { get; set; }
    public string Region { get; set; }
    public string City { get; set; }
    public string Address { get; set; }
    public char Side { get; set; }
    public string Size { get; set; }
    public string Type { get; set; }
    public bool Lighting { get; set; }
    public decimal? Price { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public int? Angle { get; set; }
    public int? DoorsDix { get; set; }
    public int? Ots { get; set; }
    public decimal? Grp { get; set; }
    public string Photo { get; set; }
    public BoardCondition Condition { get; set; }
    public string Description { get; set; }
    public string IconColor { get; set; }
    public IconStyle IconStyle { get; set; }

    public Guid PresentationId { get; set; }
}
