using Microsoft.AspNetCore.Mvc;
using OohelpWebApps.Presentations.Api.Contracts.Requests;
using OohelpWebApps.Presentations.Api.Contracts.Responses;
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
    [HttpPost]
    public async Task<ActionResult> GetAll(GetAllPresentationsRequest request)
    {
        Guid guidId;
        if (!Helpers.Guider.TryToGuidFromString(request.Key, out guidId, out _))
            return Ok(new { Status = Contracts.Common.Enums.Status.InvalidRequest });

        var response = new GetAllPresentationsResponse 
        {
            Presentations = await _presentationService.GetPresentationsAsync(Guid.NewGuid()),
            Status = Contracts.Common.Enums.Status.Ok
        };
        return Ok(response);
    }
}
