using OohelpWebApps.Presentations.Api.Contracts.Common;
using OohelpWebApps.Presentations.Domain.Authentication;
using OohelpWebApps.Presentations.Domain.Data;

namespace OohelpWebApps.Presentations.Api.Mappers;

public static class ContractDto
{
    public static PresentationDto ToDto(this PresentationContract pr, User createdByUser) => new PresentationDto
    {
        Id = pr.Id.GetValueOrDefault(Guid.Empty),
        Name = pr.Name,
        Description = pr.Description,
        CreatedAt = pr.CreatedAt.GetValueOrDefault(DateTime.Now),
        OwnerId = createdByUser.Id,
        ShowOwner = pr.ShowOwnerInfo,

        ColumnSupplier = pr.ColumnSupplier,
        ColumnPrice = pr.ColumnPrice,
        ColumnGrp = pr.ColumnGrp,
        ColumnCondition = pr.ColumnCondition,

        CardCode = pr.CardCode,
        CardMedia = pr.CardMedia,
        CardType = pr.CardType,
        CardPrice = pr.CardPrice,
        CardSide = pr.CardSide,
        CardSupplier = pr.CardSupplier,

        Boards = pr.Boards?.Select(a => a.ToDto()).ToList() ?? new List<BoardDto>(),
        Pois = pr.Pois?.Select(a => a.ToDto()).ToList() ?? new List<PoiDto>()
    };

    public static PresentationContract ToContract(this PresentationDto dto, User createdByUser) => new PresentationContract
    {
        Id = dto.Id,
        Name = dto.Name,
        Description = dto.Description,
        CreatedAt = dto.CreatedAt,
        CreatedBy = createdByUser.Username,
        ShowOwnerInfo = dto.ShowOwner,

        ColumnSupplier = dto.ColumnSupplier,
        ColumnPrice = dto.ColumnPrice,
        ColumnGrp = dto.ColumnGrp,
        ColumnCondition = dto.ColumnCondition,

        CardCode = dto.CardCode,
        CardMedia = dto.CardMedia,
        CardType = dto.CardType,
        CardPrice = dto.CardPrice,
        CardSide = dto.CardSide,
        CardSupplier = dto.CardSupplier,

        Boards = dto.Boards == null || dto.Boards.Count == 0 ? null : dto.Boards.Select(a => a.ToContract()).ToArray(),
        Pois = dto.Pois == null || dto.Pois.Count == 0 ? null : dto.Pois.Select(a => a.ToContract()).ToArray()
    };

    public static BoardDto ToDto(this BoardContract br) => new BoardDto
    {
        Id = br.Id.GetValueOrDefault(Guid.Empty),
        Address = br.Address,
        Angle = br.Angle,
        City = br.City,
        Code = br.Code,// ?? string.Empty,
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
        Type = br.Type,

        PresentationId = br.PresentationId.GetValueOrDefault(Guid.Empty),
    };

    public static BoardContract ToContract(this Domain.Data.BoardDto dto) => new BoardContract
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
        Type = dto.Type
    };
    public static PoiDto ToDto(this PoiContract poi) => new PoiDto
    {
        Id = poi.Id.GetValueOrDefault(Guid.Empty),
        Name = poi.Name,
        Description = poi.Description,
        Latitude = poi.Latitude,
        Longitude = poi.Longitude,
        IconColor = poi.IconColor,
        IconStyle = poi.IconStyle,

        PresentationId = poi.PresentationId.GetValueOrDefault(Guid.Empty),
    };

    public static PoiContract ToContract(this PoiDto poi) => new PoiContract
    {
        Id = poi.Id,
        Name = poi.Name,
        Description = poi.Description,
        Latitude = poi.Latitude,
        Longitude = poi.Longitude,
        IconColor = poi.IconColor,
        IconStyle = poi.IconStyle,
    };


}
