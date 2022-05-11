using OohelpWebApps.Presentations.Domain.Authentication;
using OohelpWebApps.Presentations.Mapping;

namespace OohelpWebApps.Presentations.Services;

public class PresentationService
{
    private readonly Domain.Repositories.Interfaces.IPresentationRepository _presentationRepository;
    private readonly InMemoryUsersRepository _usersRepository;
    public PresentationService(Domain.Repositories.Interfaces.IPresentationRepository presentationRepository, InMemoryUsersRepository clientService)
    {
        _presentationRepository = presentationRepository;
        _usersRepository = clientService;
    }

    public async Task<Models.PresentationViewModel> GetPresentationViewModelAsync(Guid presentationId)
    { 
        var presentationDto = await _presentationRepository.GetAsync(presentationId);
        if(presentationDto == null) return null;
        var result = presentationDto?.ToPresentationViewModel();
        if (presentationDto.ShowOwner)
        {
            var company = _usersRepository.GetUserById(presentationDto.OwnerId).Company;
            if(company != null)
                result.ClientInfo = new Models.ClientInfoViewModel { Logo = company.Id + ".png", Name = company.Name };
        }
        return result;
    }
    public async Task<Domain.Presentation[]> GetPresentationsByOwnerAsync(User user)
    { 
        var presentationDtos = await _presentationRepository.GetAllAsync(user.Id);
        return presentationDtos.Select(a => a.ToPresentationDomain(user)).ToArray(); 
    }
    public async Task<Domain.Presentation> CreatePresentation(Domain.Presentation presentation)
    { 
        var dto = presentation.ToPresentationDto();        
        await _presentationRepository.CreateAsync(dto);
        var res = dto.ToPresentationDomain(presentation.Owner);
        return res;
    }
}
