using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OohelpWebApps.Presentations.Domain;
using OohelpWebApps.Presentations.Domain.Authentication;
using OohelpWebApps.Presentations.Mapping;

namespace OohelpWebApps.Presentations.Controllers
{
    public class PresentationController : Controller
    {
        private readonly ILogger<PresentationController> _logger;
        private readonly AppDbContext _dbContext;
        private readonly InMemoryUsersRepository _usersRepository;
        public PresentationController(ILogger<PresentationController> logger, AppDbContext dbContext, InMemoryUsersRepository usersRepository)
        {
            _logger = logger;
            _dbContext = dbContext;
            _usersRepository = usersRepository;
        }
        public async Task<IActionResult> Show(string id)
        {
            Guid guidId;
            if (!Helpers.Guider.TryToGuidFromString(id, out guidId, out _))
                return NotFound();

            var presentationDto = await this._dbContext.Presentations.Where(a => a.Id == guidId).Include(a => a.Boards).FirstOrDefaultAsync();
            if (presentationDto == null) return NotFound();

            var model = presentationDto.ToPresentationViewModel();
            if (presentationDto.ShowOwner)
            {
                var company = _usersRepository.GetUserById(presentationDto.OwnerId).Company;
                if (company != null)
                    model.ClientInfo = new Models.ClientInfoViewModel { Logo = company.Id + ".png", Name = company.Name, Site = company.SiteUri };
            }          

            return View(model);
        }



        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
            //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

    }
}
