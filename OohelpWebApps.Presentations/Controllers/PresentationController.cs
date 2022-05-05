using Microsoft.AspNetCore.Mvc;
using OohelpWebApps.Presentations.Models;
using OohelpWebApps.Presentations.Services;
using System.Diagnostics;

namespace OohelpWebApps.Presentations.Controllers
{
    public class PresentationController : Controller
    {
        private readonly ILogger<PresentationController> _logger;
        private readonly PresentationService _presentationService;
        public PresentationController(ILogger<PresentationController> logger, PresentationService presentationService)
        {
            _logger = logger;
            _presentationService = presentationService;
        }
        public async Task<IActionResult> Show(string id)
        {
            Guid guidId;
            if (!Helpers.Guider.TryToGuidFromString(id, out guidId, out _))
                return NotFound();

            var model = await _presentationService.GetPresentationViewModelAsync(guidId);

            if(model == null) return NotFound();

            return View(model);
        }



        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
            //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

    }
}
