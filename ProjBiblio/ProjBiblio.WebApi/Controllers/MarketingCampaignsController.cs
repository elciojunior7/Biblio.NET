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
    public class MarketingCampaignsController : ControllerBase
    {
        private IMarketingCampaignService _marketingService;

        public MarketingCampaignsController(IMarketingCampaignService marketingService)
        {
            this._marketingService = marketingService;
        }

        [HttpGet]
        public MarketingCampaignListViewModel Get()
        {
            return _marketingService.Get();
        }

        [HttpGet("{id}", Name="GetMarketingsDetails")]
        public ActionResult<MarketingCampaignViewModel> Get(int id)
        {
            var result = _marketingService.Get(id);
            if (result == null)
                return NotFound();
            return _marketingService.Get(id);
        }

        [HttpPost]
        public ActionResult Post([FromBody] MarketingCampaignInputModel mkt)
        {
            var result = _marketingService.Post(mkt);
            return new CreatedAtRouteResult("GetMarketingsDetails", new {id = result.Id}, result);
        }

        [HttpDelete("{id}")]
        public ActionResult<MarketingCampaignViewModel> Delete(int id)
        {
            var result = _marketingService.Delete(id);
            if(result == null)
            {
                return NotFound();
            }
            return result;
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] MarketingCampaignInputModel mkt)
        {
            if(id != mkt.Id)
            {
                return BadRequest();
            }
            var result = _marketingService.Put(id, mkt);
            return new CreatedAtRouteResult("GetMarketingsDetails", new {id = result.Id}, result);
        }
    }
}