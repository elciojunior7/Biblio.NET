using Microsoft.AspNetCore.Mvc;
using ProjBiblio.Application.InputModels;
using ProjBiblio.Application.Interfaces;
using ProjBiblio.Application.ViewModels;

namespace ProjBiblio.WebApi.Controllers
{
    [ApiController]
    [ApiVersion( "1" )]
    [ApiVersion( "2" )]
    [Route("v{version:apiVersion}/[controller]")]
    public class KartsController : ControllerBase
    {
        private IKartService _kartService;

        public KartsController(IKartService kartService)
        {
            this._kartService = kartService;
        }

        [HttpGet("{id}", Name="GetKartsDetails")]
        public KartListViewModel Get(string id) 
        { 
            return _kartService.GetBySession(id);
        }
        
        [HttpPost]
        public ActionResult Post([FromBody] KartInputModel kart)
        {
             _kartService.Post(kart);

            return new CreatedAtRouteResult("GetKartsDetails", 
                new { id = kart.SessionUserID });
        }

        [HttpDelete("{id}")]
        public ActionResult<KartViewModel> Delete(int id)
        {
            var result = _kartService.Delete(id);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }
    }
}