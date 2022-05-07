using OohelpWebApps.Presentations.Domain.Data;

namespace OohelpWebApps.Presentations.Mapping;

public static class DomainToDtoMapper
{
    public static PresentationDto ToPresentationDto(this Domain.Presentation pr)
    {
        return new PresentationDto
        {
            Id = pr.Id,
            Name = pr.Name,
            Description = pr.Description,
            Owner = pr.Owner.Id,
            ShowOwner = pr.ShowOwnerInfo,
            Boards = pr.Boards.Select(a => a.ToBoardDto()).ToList(),
        };
    }
    public static BoardDto ToBoardDto(this Domain.Board br)
    {
        return new BoardDto
        {
            Id = br.Id,
            Address = br.Address,
            Angle = br.Angle,
            City = br.City,
            Code = br.Code,
            Condition = br.Condition,
            Description = br.Description,
            DoorsDix = br.DoorsDix,
            Grp = br.Grp,
            IconColor = br.IconColor,
            IconStyle = br.IconStyle,
            Latitude = br.Latitude,
            Longitude = br.Longitude,
            Lighting = br.Lighting,
            Ots = br.Ots,
            Photo = br.Photo,
            Price = br.Price,
            Region = br.Region,
            Side = br.Side,
            Size = br.Size,
            Supplier = br.Supplier,
            Type = br.Type
        };
    }
}
