﻿using Microsoft.AspNetCore.Mvc;
using OohelpWebApps.Presentations.Api.Contracts.Requests;
using OohelpWebApps.Presentations.Api.Contracts.Responses;
using OohelpWebApps.Presentations.Api.Exceptions;
using OohelpWebApps.Presentations.Domain.Authentication;
using OohelpWebApps.Presentations.Services;

namespace OohelpWebApps.Presentations.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PresentationsController : Controller
{
    public PresentationsController(PresentationService presentationService, InMemoryUsersRepository usersRepository)
    {
        _presentationService = presentationService;
        _usersRepository = usersRepository;
    }
    private readonly PresentationService _presentationService;
    private readonly InMemoryUsersRepository _usersRepository;

    [HttpPost("GetAll")]
    public async Task<ActionResult> GetAll(GetAllPresentationsRequest request)
    {
        try
        {
            var user = _usersRepository.Authenticate(request.Key);
            if (user == null)
                return Ok(new { Status = Contracts.Common.Enums.Status.RequestDenied });

            var result = await _presentationService.GetPresentationsByOwnerAsync(user);
            if (result == null || result.Length == 0)
                return Ok(new { Status = Contracts.Common.Enums.Status.NotFound });

            return Ok(new GetAllPresentationsResponse
            {
                Presentations = result,
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


            var conPres = new Domain.Presentation
            {
                Name = request.Name,
                Description = request.Description,
                CreatedAt = DateTime.Now,
                Owner = user,
                Boards = request.Boards,
                ShowOwnerInfo = request.ShowOwner
            };

            conPres = await _presentationService.CreatePresentation(conPres);
            
            return Ok(new CreatePresentationResponse
            {
                Presentation = conPres,
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
