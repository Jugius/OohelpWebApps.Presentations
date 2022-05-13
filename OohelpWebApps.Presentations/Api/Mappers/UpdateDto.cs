using OohelpWebApps.Presentations.Api.Contracts.Common;
using OohelpWebApps.Presentations.Domain.Data;

namespace OohelpWebApps.Presentations.Api.Mappers;

public static class UpdateDto
{
    public static void UpdateWith(this PresentationDto dto, PresentationContract presentationContract)
    {
        dto.Name = presentationContract.Name;
        dto.Description = presentationContract.Description;
        dto.ShowOwner = presentationContract.ShowOwnerInfo;
    }
}
