using OohelpWebApps.Presentations.Domain.Authentication;
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
            CreatedAt = pr.CreatedAt,
            OwnerId = pr.Owner.Id,
            ShowOwner = pr.ShowOwnerInfo,
            Boards = pr.Boards.Select(a => a.ToBoardDto()).ToList(),
        };
    }
    public static Domain.Presentation ToPresentationDomain(this Domain.Data.PresentationDto dto)
    {
        return new Domain.Presentation
        {
            Id = dto.Id,
            Name = dto.Name,
            Description = dto.Description,
            CreatedAt = dto.CreatedAt,
            ShowOwnerInfo = dto.ShowOwner,
            Boards = dto.Boards.Select(a => a.ToBoardDomain()).ToList(),
        };
    }
    public static Domain.Presentation ToPresentationDomain(this Domain.Data.PresentationDto dto, User user)
    { 
        var result = dto.ToPresentationDomain();
        result.Owner = user;
        return result;
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
    public static Domain.Board ToBoardDomain(this Domain.Data.BoardDto dto)
    {
        return new Domain.Board
        {
            Id = dto.Id,
            Region = dto.Region,
            City = dto.City,
            Address = dto.Address,
            Code = dto.Code,
            Supplier = dto.Supplier,
            Latitude = dto.Latitude,
            Longitude = dto.Longitude,
            Angle = dto.Angle,
            Condition = dto.Condition,
            Description = dto.Description,
            DoorsDix = dto.DoorsDix,
            Grp = dto.Grp,
            IconColor = dto.IconColor,
            IconStyle = dto.IconStyle,
            Lighting = dto.Lighting,
            Ots = dto.Ots,
            Photo = dto.Photo,
            Price = dto.Price,
            Side = dto.Side,
            Size = dto.Size,
            Type = dto.Type,
        };
    }
}
