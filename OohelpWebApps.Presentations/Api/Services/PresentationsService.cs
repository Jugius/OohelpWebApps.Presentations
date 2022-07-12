using Microsoft.EntityFrameworkCore;
using OohelpWebApps.Presentations.Api.Contracts.Requests;
using OohelpWebApps.Presentations.Api.Mappers;
using OohelpWebApps.Presentations.Api.Services.Helpers;
using OohelpWebApps.Presentations.Database;
using OohelpWebApps.Presentations.Domain;
using OohelpWebApps.Presentations.Domain.Authentication;
using OohelpWebApps.Presentations.Helpers;

namespace OohelpWebApps.Presentations.Api.Services;
public class PresentationsService
{
    private readonly AppDbContext _dbContext;
    private readonly AuthenticationService _usersRepository;

    public PresentationsService(AppDbContext dbContext, AuthenticationService usersRepository)
    {
        _dbContext = dbContext;
        _usersRepository = usersRepository;
    }

    public async Task<OperationResult<Presentation>> Create(CreatePresentationRequest request)
    {
        var userResult = _usersRepository.Authenticate(request.Key);

        if (!userResult.Success)
            return new OperationResult<Presentation>(userResult.Error);


        var dto = request.ToDto();
        dto.OwnerId = userResult.Value.Id;
        
        try
        {
            _dbContext.Presentations.Add(dto);
            await _dbContext.SaveChangesAsync();
            return new OperationResult<Presentation>(dto.ToDomain(userResult.Value));
        }
        catch (Exception ex)
        {
            return OperationResult<Presentation>.DatabaseError(ex.GetBaseException().Message);
        }
    }

    public async Task<OperationResult<Presentation>> Update(UpdatePresentationRequest request)
    {
        var userResult = _usersRepository.Authenticate(request.Key);

        if (!userResult.Success)
            return new OperationResult<Presentation>(userResult.Error);

        try
        {
            var dto = await _dbContext.Presentations.FirstOrDefaultAsync(a => a.Id == request.Id);

            if (dto == null)
                return OperationResult<Presentation>.NotFound();

            if (dto.OwnerId != userResult.Value.Id)
                return OperationResult<Presentation>.RequestDenied();

            dto.UpdateWith(request);

            await _dbContext.SaveChangesAsync();
            return new OperationResult<Presentation>(dto.ToDomain(userResult.Value));
        }
        catch (Exception ex)
        {
            return OperationResult<Presentation>.DatabaseError(ex.GetBaseException().Message);
        }
    }
    public async Task<OperationResult<bool>> Delete(DeleteRequest request)
    {
        var userResult = _usersRepository.Authenticate(request.Key);

        if (!userResult.Success)
            return new OperationResult<bool>(userResult.Error);

        try
        {
            var dto = await _dbContext.Presentations.FirstOrDefaultAsync(a => a.Id == request.Id);

            if (dto == null)
                return OperationResult<bool>.NotFound();

            if (dto.OwnerId != userResult.Value.Id)
                return OperationResult<bool>.RequestDenied();

            _dbContext.Presentations.Remove(dto);
            await _dbContext.SaveChangesAsync();
            return new OperationResult<bool>(true);
        }
        catch (Exception ex)
        {
            return OperationResult<bool>.DatabaseError(ex.GetBaseException().Message);
        }
    }
    public async Task<OperationResult<Presentation[]>> GetAll(GetAllPresentationsRequest request)
    {
        var userResult = _usersRepository.Authenticate(request.Key);

        if (!userResult.Success)
            return new OperationResult<Presentation[]>(userResult.Error);

        var user = userResult.Value;

        if (request.ShowAllAvailable && user.Company != null)
            return await GetAllByCompanyId(user.Company.Id);

        try
        {
            var presentations = await _dbContext.Presentations.Where(a => a.OwnerId == user.Id).ToArrayAsync();
            return new OperationResult<Presentation[]>(presentations.Select(a => a.ToDomain(user)).ToArray());
        }
        catch (Exception ex)
        {
            return OperationResult<Presentation[]>.DatabaseError(ex.GetBaseException().Message);
        }
    }

    private async Task<OperationResult<Presentation[]>> GetAllByCompanyId(Guid companyId)
    {
        var users = _usersRepository.GetUsersByCompanyId(companyId).ToArray();
        if (users.Length == 0)
            return new OperationResult<Presentation[]>(new Presentation[0]);        

        try
        {
            Dictionary<Guid, User> usersDic = users.ToDictionary(a => a.Id, a => a);
            var hashset = users.Select(a => a.Id).ToHashSet();
            var presentations = await _dbContext.Presentations.Where(a=> hashset.Contains(a.OwnerId)).ToArrayAsync();

            var domain = presentations.Select(a => a.ToDomain(usersDic[a.OwnerId])).ToArray();

            return new OperationResult<Presentation[]>(domain);

        }
        catch (Exception ex)
        {
            return OperationResult<Presentation[]>.DatabaseError(ex.GetBaseException().Message);
        }
    }
    public async Task<OperationResult<Presentation>> Get(GetPresentationRequest request)
    {
        var userResult = _usersRepository.Authenticate(request.Key);

        if (!userResult.Success)
            return new OperationResult<Presentation>(userResult.Error);

        var user = userResult.Value;

        var presentationResult = await Get(request.Id);

        if (!presentationResult.Success)
            return new OperationResult<Presentation>(presentationResult.Error);

        var presentation = presentationResult.Value;

        if (_usersRepository.AllowGetPresentation(user, presentation.Owner))
            return new OperationResult<Presentation>(presentation);

        return OperationResult<Presentation>.RequestDenied();
    }

    public async Task<OperationResult<Presentation>> Get(Guid id)
    {
        if (id == Guid.Empty)
            return OperationResult<Presentation>.InvalidRequest();      
        
        try
        {
            var dto = await _dbContext.Presentations
                .Include(a => a.Boards)
                .Include(a => a.Pois)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (dto == null)
                return OperationResult<Presentation>.NotFound();

            var owner = _usersRepository.GetUserById(dto.OwnerId);

            return new OperationResult<Presentation>(dto.ToDomain(owner));
        }
        catch (Exception ex)
        {
            return OperationResult<Presentation>.DatabaseError(ex.GetBaseException().Message);
        }
    }

    public async Task<OperationResult<Presentation>> Get(string id)
    {
        Guid guidId;
        if (!Guider.TryToGuidFromString(id, out guidId, out _))
            return OperationResult<Presentation>.InvalidRequest();

        return await Get(guidId);
    }
}
