using Microsoft.AspNetCore.Mvc;
using OohelpWebApps.Presentations.Api.Services;
using OohelpWebApps.Presentations.Mapping;

namespace OohelpWebApps.Presentations.Controllers
{
    public class PresentationController : Controller
    {
        private readonly Api.Services.PresentationsService presentationsService;
        private readonly IConfiguration configuration;

        public PresentationController(PresentationsService presentationsService, IConfiguration configuration)
        {
            this.presentationsService = presentationsService;
            this.configuration = configuration;
        }

        public async Task<IActionResult> Show(string id)
        {
            Guid guidId;
            if (!Helpers.Guider.TryToGuidFromString(id, out guidId, out _))
                return BadRequest();

            var result = await this.presentationsService.Get(guidId);

            if(!result.Success)
                return NotFound();


            var model = result.Value.ToViewModel();
            model.GoogleMapApiKey = this.configuration.GetValue<string>("GoogleMapApiKey");

            return View(model);

        }



        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
            //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

    }
}
