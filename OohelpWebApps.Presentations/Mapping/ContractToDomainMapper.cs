using OohelpWebApps.Presentations.Api.Contracts.Requests;

namespace OohelpWebApps.Presentations.Mapping
{
    public static class ContractToDomainMapper
    {
        public static Domain.Presentation ToPresentationDomain(this CreatePresentationRequest request)
        {
            return new Domain.Presentation
            {
                Name = request.Name,
                Description = request.Description,
                ShowOwnerInfo = request.ShowOwner,
                Boards = request.Boards
            };
        }
    }
}
