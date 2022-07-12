using OohelpWebApps.Presentations.Database.Dto;
using OohelpWebApps.Presentations.Domain;


namespace OohelpWebApps.Presentations.Api.Mappers;
public static class DomainToDto
{
    public static BoardDto ToDto(this Board board) =>
        new BoardDto
        {
            Id = board.Id,
            Region = board.Region,
            City = board.City,
            Address = board.Address,
            Code = board.Code,
            Supplier = board.Supplier,
            Latitude = board.Latitude,
            Longitude = board.Longitude,
            Angle = board.Angle,
            Condition = board.Condition,
            Description = board.Description,
            DoorsDix = board.DoorsDix,
            Grp = board.Grp,
            IconColor = board.IconColor,
            IconStyle = (int)board.IconStyle,
            Lighting = board.Lighting,
            Ots = board.Ots,
            Photo = board.Photo,
            Price = board.Price,
            Side = board.Side,
            Size = board.Size,
            Type = board.Type,
            PresentationId = board.PresentationId
        };

    public static PoiDto ToDto(this Poi poi) =>
        new PoiDto
        {
            Id = poi.Id,
            Name = poi.Name,
            Description = poi.Description,
            Latitude = poi.Latitude,
            Longitude = poi.Longitude,
            IconColor = poi.IconColor,
            IconStyle = (int)poi.IconStyle,
            PresentationId = poi.PresentationId
        };
}
