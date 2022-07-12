using OohelpWebApps.Presentations.Api.Contracts.Requests;
using OohelpWebApps.Presentations.Database.Dto;

namespace OohelpWebApps.Presentations.Api.Mappers;

public static class UpdateDto
{
    public static void UpdateWith(this PresentationDto dto, UpdatePresentationRequest request)
    {
        dto.Name = request.Name;
        dto.Description = request.Description;
        dto.ShowOwner = request.ShowOwnerInfo;

        dto.ColumnAddress = request.ColumnAddress;
        dto.ColumnCity = request.ColumnCity;
        dto.ColumnCondition = request.ColumnCondition;
        dto.ColumnPrice = request.ColumnPrice;
        dto.ColumnSupplier = request.ColumnSupplier;
        dto.ColumnSupplierCode = request.ColumnSupplierCode;
        dto.ColumnTypeSize = request.ColumnTypeSize;
        dto.ColumnGrp = request.ColumnGrp;

        dto.CardCode = request.CardCode;
        dto.CardMedia = request.CardMedia;
        dto.CardPrice = request.CardPrice;
        dto.CardSide = request.CardSide;
        dto.CardSupplier = request.CardSupplier;
        dto.CardType = request.CardType;
    }
}
