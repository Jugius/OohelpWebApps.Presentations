using Microsoft.AspNetCore.Mvc;
using OohelpWebApps.Presentations.Api.Contracts.Requests;
using OohelpWebApps.Presentations.Api.Mappers;
using OohelpWebApps.Presentations.Api.Services;

namespace OohelpWebApps.Presentations.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PresentationsController : Controller
{
    private readonly PresentationsService _presentationsService;

    public PresentationsController(PresentationsService presentationsService)
    {
        _presentationsService = presentationsService;
    }

    [HttpPost("GetAll")]
    public async Task<ActionResult> GetAll(GetAllPresentationsRequest request)
    {
        var result = await _presentationsService.GetAll(request);

        if (result.Success)
            return Json(result.Value.ToResponse());
        else
            return Json(result.Error.ToResponse());
    }
    [HttpPost("ById")]
    public async Task<ActionResult> GetById(GetPresentationRequest request)
    {
        var result = await _presentationsService.Get(request);

        if (result.Success)
            return Json(result.Value.ToResponse());
        else
            return Json(result.Error.ToResponse());
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreatePresentationRequest request)
    {
        var result = await _presentationsService.Create(request);

        if (result.Success)
            return Json(result.Value.ToResponse());
        else
            return Json(result.Error.ToResponse());        
    }

    [HttpPut]
    public async Task<ActionResult> Update(UpdatePresentationRequest request)
    {
        var result = await _presentationsService.Update(request);

        if (result.Success)
            return Json(result.Value.ToResponse());
        else
            return Json(result.Error.ToResponse());
    }

    [HttpDelete]
    public async Task<ActionResult> Delete(DeleteRequest request)
    {
        var result = await _presentationsService.Delete(request);

        if (result.Success)
            return Json(Contracts.Response.Ok);
        else
            return Json(result.Error.ToResponse());
    }
}
