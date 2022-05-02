
using OohelpWebApps.Presentations.Domain.Data;

namespace OohelpWebApps.Presentations.Domain.Repositories.Interfaces;

public interface IPresentationRepository
{
    Task<bool> CreateAsync(PresentationDto presentation);

    Task<PresentationDto> GetAsync(Guid id);

    Task<IEnumerable<PresentationDto>> GetAllAsync();

    Task<bool> UpdateAsync(PresentationDto presentation);

    Task<bool> DeleteAsync(Guid id);
}
