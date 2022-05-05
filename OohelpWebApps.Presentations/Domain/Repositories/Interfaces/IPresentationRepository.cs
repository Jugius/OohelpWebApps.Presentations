
using OohelpWebApps.Presentations.Domain.Data;

namespace OohelpWebApps.Presentations.Domain.Repositories.Interfaces;

public interface IPresentationRepository
{
    IQueryable<PresentationDto> Presentations { get; }
    Task<bool> CreateAsync(PresentationDto presentation);
    Task<PresentationDto> GetAsync(Guid id);
    Task<IEnumerable<PresentationDto>> GetAllAsync(Guid ownerId);
    Task<bool> UpdateAsync(PresentationDto presentation);
    Task<bool> DeleteAsync(Guid id);
}
