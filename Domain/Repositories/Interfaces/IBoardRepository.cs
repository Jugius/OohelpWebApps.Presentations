using OohelpWebApps.Presentations.Domain.Data;

namespace OohelpWebApps.Presentations.Domain.Repositories.Interfaces;

public interface IBoardRepository
{
    Task<bool> CreateAsync(BoardDto board);

    Task<BoardDto?> GetAsync(Guid id);

    Task<IEnumerable<BoardDto>> GetAllAsync();

    Task<bool> UpdateAsync(BoardDto board);

    Task<bool> DeleteAsync(Guid id);
}
