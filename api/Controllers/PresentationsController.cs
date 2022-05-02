using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OohelpWebApps.Presentations.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresentationsController : Controller
    {
        [HttpGet]
        public async Task<ActionResult> Get()
        {            
            return Json(new { Status = "Ok"});
        }
    }
}
