using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjBiblioFront.Models;

namespace ProjBiblioFront.Controllers
{
    public class KartsController : Controller
    {
        private readonly ILogger<KartsController> _logger;
        private readonly HttpClient _httpClient;
        private readonly string baseUrl = $"/v1/Karts";

        public KartsController(ILogger<KartsController> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            string key = GetKartKey();

            var url = baseUrl+"/"+key;
            var resposta = await _httpClient.GetFromJsonAsync<KartListViewModel>(url);

            return View("List", resposta.Items);
        }

        [HttpGet, ActionName("Add")]
        public async Task<ActionResult> Add(int id)
        {
            var kart = new KartViewModel()
            {
                BookId = id,
                BookAmount = 1,
                SessionUserID = GetKartKey()
            };

            var url = baseUrl;
            var resposta = await _httpClient.PostAsJsonAsync<KartViewModel>(url, kart);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet, ActionName("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var url = baseUrl+"/"+id;
            var resposta = await _httpClient.DeleteAsync(url);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet, ActionName("LoanBooks")]
        public async Task<IActionResult> LoanBooks()
        {
            var url = $"/v1/Loans";
            var emprestimo = new LoanInputModel()
            {
                SessionUserId = GetKartKey()
            };

            var resposta = await _httpClient.PostAsJsonAsync(url, emprestimo);

            if (!resposta.IsSuccessStatusCode)
            {
                return BadRequest();
            }

            TempData.Remove("KartKey");
            
            return RedirectToAction("Index", "Loans");
        }

        [HttpGet, ActionName("CleanKart")]
        public IActionResult CleanKart()
        {
            TempData.Remove("KartKey");
            return RedirectToAction(nameof(Index));
        }

        private string GetKartKey()
        {
            if (TempData["KartKey"] == null)
            {
                TempData["KartKey"] = Guid.NewGuid().ToString();
            }

            TempData.Keep("KartKey");

            return TempData["KartKey"].ToString();
        }
    }
}