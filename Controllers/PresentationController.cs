using Microsoft.AspNetCore.Mvc;
using OohelpWebApps.Presentations.Models;

namespace OohelpWebApps.Presentations.Controllers
{
    public class PresentationController : Controller
    {
        public PresentationController(ILogger<PresentationController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index(Guid id)
        {
            var model = PresentationModel.Default;
            return View(model);
        }
        
        private readonly ILogger<PresentationController> _logger;      

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
            //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

    }
}
