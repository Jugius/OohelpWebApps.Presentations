using OohelpWebApps.Presentations.Mapping;

namespace OohelpWebApps.Presentations.Services
{
    public class PresentationService
    {
        private readonly Domain.Repositories.Interfaces.IPresentationRepository _presentationRepository;
        public PresentationService(Domain.Repositories.Interfaces.IPresentationRepository presentationRepository) => _presentationRepository = presentationRepository;

        public async Task<Models.PresentationViewModel?> GetPresentationAsync(Guid presentationId)
        { 
            var presentationDto = await _presentationRepository.GetAsync(presentationId);
            return presentationDto?.ToPresentationViewModel();
        }        
    }
}
