using OohelpWebApps.Presentations.Database.Dto;
using OohelpWebApps.Presentations.Domain;
using OohelpWebApps.Presentations.Domain.Authentication;

namespace OohelpWebApps.Presentations.Api.Mappers;
public static class DtoToDomain
{
    public static Presentation ToDomain(this PresentationDto dto, User owner) =>
        new Presentation
        {
            Id = dto.Id,
            Name = dto.Name,
            Description = dto.Description,
            CreatedAt = dto.CreatedAt,
            ShowOwnerInfo = dto.ShowOwner,

            CardCode = dto.CardCode,
            CardMedia = dto.CardMedia,
            CardPrice = dto.CardPrice,
            CardSide = dto.CardSide,
            CardType = dto.CardType,
            CardSupplier = dto.CardSupplier,
            ColumnAddress = dto.ColumnAddress,
            ColumnCity = dto.ColumnCity,
            ColumnSupplier = dto.ColumnSupplier,
            ColumnCondition = dto.ColumnCondition,
            ColumnGrp = dto.ColumnGrp,
            ColumnSupplierCode = dto.ColumnSupplierCode,
            ColumnTypeSize = dto.ColumnTypeSize,
            ColumnPrice = dto.ColumnPrice,

            Boards = dto.Boards?.Select(a => a.ToDomain()).ToList() ?? new List<Board>(),
            Pois = dto.Pois?.Select(a => a.ToDomain()).ToList() ?? new List<Poi>(),

            Owner = owner
        };

    public static Board ToDomain(this BoardDto dto) =>
        new Board
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
            IconStyle = (Domain.Common.Enums.IconStyle)dto.IconStyle,
            Lighting = dto.Lighting,
            Ots = dto.Ots,
            Photo = dto.Photo,
            Price = dto.Price,
            Side = dto.Side,
            Size = dto.Size,
            Type = dto.Type
        };

    public static Poi ToDomain(this PoiDto dto) =>
        new Poi
        {
            Id = dto.Id,
            Name = dto.Name,
            Description = dto.Description,
            Latitude = dto.Latitude,
            Longitude = dto.Longitude,
            IconColor = dto.IconColor,
            IconStyle = (Domain.Common.Enums.IconStyle)dto.IconStyle,
            PresentationId = dto.PresentationId
        };
}
