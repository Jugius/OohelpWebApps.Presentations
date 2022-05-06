using Microsoft.AspNetCore.Mvc;
using OohelpWebApps.Presentations.Api.Contracts.Requests;
using OohelpWebApps.Presentations.Api.Contracts.Responses;
using OohelpWebApps.Presentations.Mapping;
using OohelpWebApps.Presentations.Services;

namespace OohelpWebApps.Presentations.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PresentationsController : Controller
{
    public PresentationsController(PresentationService presentationService)
    {
        _presentationService = presentationService;
    }
    private readonly PresentationService _presentationService;

    [HttpPost("GetAll")]
    public async Task<ActionResult> GetAll(GetAllPresentationsRequest request)
    {
        Guid guidId;
        if (!Helpers.Guider.TryToGuidFromString(request.Key, out guidId, out _))
            return Ok(new { Status = Contracts.Common.Enums.Status.InvalidRequest });

        var result = await _presentationService.GetPresentationsByOwnerAsync(Guid.NewGuid());
        if(result == null || result.Length == 0)
            return Ok(new { Status = Contracts.Common.Enums.Status.NotFound });

        var response = new GetAllPresentationsResponse 
        {
            Presentations = result,
            Status = Contracts.Common.Enums.Status.Ok
        };
        return Ok(response);
    }

    [HttpPost("Create")]
    public async Task<ActionResult> Create(CreatePresentationRequest request)
    {
        Guid guidId;
        if (!Helpers.Guider.TryToGuidFromString(request.Key, out guidId, out _))
            return Ok(new { Status = Contracts.Common.Enums.Status.InvalidRequest });

        var conPres = request.ToPresentationDomain();
        Domain.Presentation result = await _presentationService.Create(conPres);


        
    }
}
