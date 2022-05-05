using OohelpWebApps.Presentations.Mapping;

namespace OohelpWebApps.Presentations.Services;

public class PresentationService
{
    private readonly Domain.Repositories.Interfaces.IPresentationRepository _presentationRepository;
    private readonly ClientService _clientService;
    public PresentationService(Domain.Repositories.Interfaces.IPresentationRepository presentationRepository, ClientService clientService)
    {
        _presentationRepository = presentationRepository;
        _clientService = clientService;
    }

    public async Task<Models.PresentationViewModel?> GetPresentationViewModelAsync(Guid presentationId)
    { 
        var presentationDto = await _presentationRepository.GetAsync(presentationId);
        if(presentationDto == null) return null;
        var result = presentationDto?.ToPresentationViewModel();
        if (presentationDto.ShowOwner)
        {
            result.ClientInfo = await _clientService.GetClientInfo(presentationDto.Owner);
        }
        return result;
    }
    public async Task<Domain.Presentation[]> GetPresentationsAsync(Guid ownerId)
    { 
        var presentationDtos = await _presentationRepository.GetAllAsync(ownerId);
        var presentations = presentationDtos.Select(a => a.ToPresentationDomain()).ToArray();
        return presentations;
    }
}
