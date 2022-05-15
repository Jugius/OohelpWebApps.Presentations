using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OohelpWebApps.Presentations.Api.Contracts.Requests;
using OohelpWebApps.Presentations.Api.Contracts.Responses;
using OohelpWebApps.Presentations.Api.Exceptions;
using OohelpWebApps.Presentations.Domain;
using OohelpWebApps.Presentations.Domain.Authentication;
using OohelpWebApps.Presentations.Api.Mappers;

namespace OohelpWebApps.Presentations.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PresentationsController : Controller
{
    public PresentationsController(AppDbContext dbContext, InMemoryUsersRepository usersRepository)
    {
        _dbContext = dbContext;
        _usersRepository = usersRepository;
    }
    private readonly AppDbContext _dbContext;
    private readonly InMemoryUsersRepository _usersRepository;

    [HttpPost("GetAll")]
    public async Task<ActionResult> GetAll(GetAllPresentationsRequest request)
    {
        try
        {
            var user = _usersRepository.Authenticate(request.Key);
            if (user == null)
                return Ok(new { Status = Contracts.Common.Enums.Status.RequestDenied });

            var result = await _dbContext.Presentations.Where(a => a.OwnerId == user.Id).Include(a => a.Boards).ToListAsync();
            if (result.Count == 0)
                return Ok(new { Status = Contracts.Common.Enums.Status.NotFound });

            return Ok(new PresentationsResponse
            {
                Presentations = result.Select(a => a.ToContract(user)).ToArray(),
                Status = Contracts.Common.Enums.Status.Ok
            });

        }
        catch (ApiException apex)
        {
            return Ok(new { Status = apex.Status });
        }
        catch (Exception ex)
        {
            return Ok(new { Status = Contracts.Common.Enums.Status.UnknownError, ErrorMessage = ex.Message });
        }
    }

    [HttpPost("Create")]
    public async Task<ActionResult> Create(PresentationRequest request)
    {
        try
        {
            var user = _usersRepository.Authenticate(request.Key);
            if (user == null || !user.HasPermission(Permission.CreateNewPresentation))
                return Ok(new { Status = Contracts.Common.Enums.Status.RequestDenied });

            var dto = request.Presentation.ToDto(user);

            this._dbContext.Presentations.Add(dto);
            await this._dbContext.SaveChangesAsync();
            
            return Ok(new PresentationResponse
            {
                Presentation = dto.ToContract(user),
                Status = Contracts.Common.Enums.Status.Ok
            });
        }
        catch (ApiException apex)
        {
            return Ok(new { Status = apex.Status });
        }
        catch (Exception ex)
        {
            return Ok(new { Status = Contracts.Common.Enums.Status.UnknownError, ErrorMessage = ex.Message });
        }
    }
    [HttpPost("Update")]
    public async Task<ActionResult> Update(PresentationRequest request)
    {
        try
        {
            var user = _usersRepository.Authenticate(request.Key);
            if (user == null || !user.HasPermission(Permission.UpdatePresentation))
                return Ok(new { Status = Contracts.Common.Enums.Status.RequestDenied });

            var existing = await this._dbContext.Presentations.FirstOrDefaultAsync(a=>a.Id == request.Presentation.Id);

            if(existing == null)
                return Ok(new { Status = Contracts.Common.Enums.Status.NotFound });

            existing.UpdateWith(request.Presentation);

            await this._dbContext.SaveChangesAsync();

            return Ok(new PresentationResponse
            {
                Presentation = existing.ToContract(user),
                Status = Contracts.Common.Enums.Status.Ok
            });
        }
        catch (ApiException apex)
        {
            return Ok(new { Status = apex.Status });
        }
        catch (Exception ex)
        {
            return Ok(new { Status = Contracts.Common.Enums.Status.UnknownError, ErrorMessage = ex.Message });
        }
    }
}
