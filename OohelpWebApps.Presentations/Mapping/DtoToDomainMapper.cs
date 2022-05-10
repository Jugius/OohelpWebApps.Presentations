
using OohelpWebApps.Presentations.Domain.Authentication;

namespace OohelpWebApps.Presentations.Mapping;

public static class DtoToDomainMapper
{
    public static Domain.Presentation ToPresentationDomain(this Domain.Data.PresentationDto dto)
    {
        return new Domain.Presentation
        {
            Id = dto.Id,
            Name = dto.Name,
            Description = dto.Description,
            CreatedAt = dto.Created,
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
