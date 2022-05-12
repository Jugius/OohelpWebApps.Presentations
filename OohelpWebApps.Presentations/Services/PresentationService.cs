using OohelpWebApps.Presentations.Domain.Authentication;
using OohelpWebApps.Presentations.Mapping;

namespace OohelpWebApps.Presentations.Services;

public class PresentationService
{
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

    
}
