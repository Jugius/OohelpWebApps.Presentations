using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OohelpWebApps.Presentations.Api.Contracts.Requests;
using OohelpWebApps.Presentations.Api.Contracts.Responses;
using OohelpWebApps.Presentations.Api.Exceptions;
using OohelpWebApps.Presentations.Domain;
using OohelpWebApps.Presentations.Domain.Authentication;
using OohelpWebApps.Presentations.Mapping;

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
                Presentations = result.Select(a => a.ToPresentationDomain(user)).ToArray(),
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
    public async Task<ActionResult> Create(CreatePresentationRequest request)
    {
        try
        {
            var user = _usersRepository.Authenticate(request.Key);
            if (user == null || !user.HasPermission(Permission.CreateNewPresentation))
                return Ok(new { Status = Contracts.Common.Enums.Status.RequestDenied });

            var dto = new Domain.Data.PresentationDto
            {
                Name = request.Name,
                Description = request.Description,
                CreatedAt = DateTime.Now,
                OwnerId = user.Id,
                Boards = request.Boards?.Select(a => a.ToBoardDto()).ToList() ?? new List<Domain.Data.BoardDto>(0),
                ShowOwner = request.ShowOwner
            };

            this._dbContext.Presentations.Add(dto);
            await this._dbContext.SaveChangesAsync();
            
            return Ok(new PresentationResponse
            {
                Presentation = dto.ToPresentationDomain(user),
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
    public async Task<ActionResult> Update(UpdatePresentationRequest request)
    {
        try
        {
            var user = _usersRepository.Authenticate(request.Key);
            if (user == null || !user.HasPermission(Permission.UpdatePresentation))
                return Ok(new { Status = Contracts.Common.Enums.Status.RequestDenied });

            var existing = await this._dbContext.Presentations.FirstOrDefaultAsync(a=>a.Id == request.Id);

            if(existing == null)
                return Ok(new { Status = Contracts.Common.Enums.Status.NotFound });

            existing.Name = request.Name;
            existing.Description = request.Description;
            existing.ShowOwner = request.ShowOwner;

            await this._dbContext.SaveChangesAsync();

            return Ok(new PresentationResponse
            {
                Presentation = existing.ToPresentationDomain(user),
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
