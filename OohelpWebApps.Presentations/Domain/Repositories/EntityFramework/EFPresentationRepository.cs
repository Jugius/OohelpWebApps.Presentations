using Microsoft.EntityFrameworkCore;
using OohelpWebApps.Presentations.Domain.Data;


namespace OohelpWebApps.Presentations.Domain.Repositories.EntityFramework
{
    public class EFPresentationRepository : Interfaces.IPresentationRepository
    {
        private readonly AppDbContext dbContext;
        public EFPresentationRepository(AppDbContext context) => dbContext = context;

        public IQueryable<PresentationDto> Presentations => this.dbContext.Presentations;

        public async Task<IEnumerable<PresentationDto>> GetAllAsync(Guid ownerId)
        {
            return await this.Presentations.Where(a => a.OwnerId == ownerId).Include(a => a.Boards).ToListAsync();
        }

        public async Task<PresentationDto> CreateAsync(PresentationDto presentation)
        {
            this.dbContext.Presentations.Add(presentation);
            await this.dbContext.SaveChangesAsync();
            return presentation;
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }       

        public Task<PresentationDto> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(PresentationDto presentation)
        {
            throw new NotImplementedException();
        }
    }
}
