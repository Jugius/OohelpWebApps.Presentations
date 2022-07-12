using OohelpWebApps.Presentations.Api.Contracts.Requests;
using OohelpWebApps.Presentations.Database.Dto;

namespace OohelpWebApps.Presentations.Api.Mappers;
public static class ContractToDto
{
    public static PresentationDto ToDto(this CreatePresentationRequest pr) =>
        new PresentationDto
        {
            Id = Guid.Empty,
            Name = pr.Name,
            Description = pr.Description,
            CreatedAt = DateTime.Now.ToUniversalTime(),
            ShowOwner = pr.ShowOwnerInfo,

            ColumnSupplier = pr.ColumnSupplier,
            ColumnPrice = pr.ColumnPrice,
            ColumnGrp = pr.ColumnGrp,
            ColumnCondition = pr.ColumnCondition,

            ColumnAddress = pr.ColumnAddress,
            ColumnCity = pr.ColumnCity,
            ColumnSupplierCode = pr.ColumnSupplierCode,
            ColumnTypeSize = pr.ColumnTypeSize,

            CardCode = pr.CardCode,
            CardMedia = pr.CardMedia,
            CardType = pr.CardType,
            CardPrice = pr.CardPrice,
            CardSide = pr.CardSide,
            CardSupplier = pr.CardSupplier,

            Boards = (pr.Boards == null || pr.Boards.Length == 0)
            ? new List<BoardDto>(0)
            : pr.Boards.Select(a => a.ToDto()).ToList(),

            Pois = (pr.Pois == null || pr.Pois.Length == 0)
            ? new List<PoiDto>(0)
            : pr.Pois.Select(a => a.ToDto()).ToList()
        };
}