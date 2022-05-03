using Microsoft.AspNetCore.Mvc;
using OohelpWebApps.Presentations.Models;
using OohelpWebApps.Presentations.Services;

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
        public async Task<IActionResult> Index(string id)
        {            
            if (string.IsNullOrEmpty(id))
                return NotFound();

            var model = await _presentationService.GetPresentationAsync(Guid.NewGuid());
            return View(model);
        }
        
        

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
            //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

    }
}
