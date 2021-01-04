using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjBiblio.Application.InputModels;
using ProjBiblioFront.Models;

namespace ProjBiblioFront.Controllers
{
    public class MarketingCampaignsController : Controller
    {
        private HttpClient _httpClient;
        private readonly ILogger<MarketingCampaignsController> _logger;
        private readonly string baseUrl = $"/v1/MarketingCampaigns";

        public MarketingCampaignsController(ILogger<MarketingCampaignsController> logger, HttpClient httpClient)
        {
            this._logger = logger;
            this._httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var url = baseUrl;
            var resposta = await _httpClient.GetFromJsonAsync<MarketingCampaignListViewModel>(url);

            return View("List", resposta.MarketingCampaigns);
        }

        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var url = baseUrl+"/"+id;
            var resposta = await _httpClient.GetFromJsonAsync<MarketingCampaignViewModel>(url);

            if (resposta == null)
            {
                return NotFound();
            }

            return View(resposta);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,StartDate,EndDate,DiscountPercentage")] MarketingCampaignInputModel mkt,
            string[] selectedBooks)
        {
            if (selectedBooks != null)
            {
                mkt.Books = new List<BookSelectListDto>();

                foreach (var idBook in selectedBooks)
                    mkt.Books.Add(new BookSelectListDto() { BookID = int.Parse(idBook), Selected = true });
            }

            var url = baseUrl;
            var resposta = await _httpClient.PostAsJsonAsync<MarketingCampaignInputModel>(url, mkt);

            if (resposta.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            var mensagens = await resposta.Content.ReadFromJsonAsync<BadRequestResponse>();

            foreach (var atrError in mensagens.Errors)
            {
                foreach(var erro in atrError.Value)
                    ModelState.AddModelError(atrError.Key, erro);
            }
                
            return View(mkt);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var url = baseUrl+"/"+id;
            var resposta = await _httpClient.GetFromJsonAsync<MarketingCampaignInputModel>(url);
            return View(resposta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,StartDate,EndDate,DiscountPercentage")] MarketingCampaignInputModel mkt,
            string[] selectedBooks)
        {
            if (id != mkt.Id)
            {
                return NotFound();
            }

            if (selectedBooks != null)
            {
                mkt.Books = new List<BookSelectListDto>();

                foreach (var idBook in selectedBooks)
                    mkt.Books.Add(new BookSelectListDto() { BookID = int.Parse(idBook), Selected = true });
            }

            var url = baseUrl+"/"+id;
            var resposta = await _httpClient.PutAsJsonAsync<MarketingCampaignInputModel>(url, mkt);

            if (resposta.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.ErrorMessage = resposta;
                
            return View(resposta);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var url = baseUrl+"/"+id;
            var resposta = await _httpClient.GetFromJsonAsync<MarketingCampaignViewModel>(url);

            if (resposta == null)
            {
                return NotFound();
            }

            return View(resposta);
        }

        // POST: Marketings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var url = baseUrl+"/"+id;
            var resposta = await _httpClient.DeleteAsync(url);

            return RedirectToAction(nameof(Index));
        } 
    }
}