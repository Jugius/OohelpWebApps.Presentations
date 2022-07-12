using OohelpWebApps.Presentations.Api.Contracts.Common;
using OohelpWebApps.Presentations.Domain;

namespace OohelpWebApps.Presentations.Api.Mappers;
public static class DomainToContract
{
    public static PresentationContract ToContract(this Presentation presentation) =>
        new PresentationContract
        {
            Id = presentation.Id,
            Name = presentation.Name,
            Description = presentation.Description,
            ShowOwnerInfo = presentation.ShowOwnerInfo,

            CreatedAt = presentation.CreatedAt,
            CreatedBy = presentation.Owner.Username,

            CardCode = presentation.CardCode,
            CardMedia = presentation.CardMedia,
            CardPrice = presentation.CardPrice,
            CardSide = presentation.CardSide,
            CardSupplier = presentation.CardSupplier,
            CardType = presentation.CardType,
            ColumnAddress = presentation.ColumnAddress,
            ColumnCity = presentation.ColumnCity,
            ColumnSupplier = presentation.ColumnSupplier,
            ColumnSupplierCode = presentation.ColumnSupplierCode,
            ColumnTypeSize = presentation.ColumnTypeSize,
            ColumnCondition = presentation.ColumnCondition,
            ColumnGrp = presentation.ColumnGrp,
            ColumnPrice = presentation.ColumnPrice,

            Boards = (presentation.Boards != null && presentation.Boards.Count > 0)
            ? presentation.Boards.ToArray()
            : null,

            Pois = (presentation.Pois != null && presentation.Pois.Count > 0)
            ? presentation.Pois.ToArray()
            : null
        };
}
