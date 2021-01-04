using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjBiblioFront.Models;

namespace ProjBiblioFront.Controllers
{
    public class GenresController : Controller
    {
        private readonly ILogger<GenresController> _logger;
        private readonly HttpClient _httpClient;

        private readonly string baseUrl = $"/v1/Genres";

        public GenresController(ILogger<GenresController> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        // GET: Genres
        public async Task<IActionResult> Index()
        {
            var url = baseUrl;
            var resposta = await _httpClient.GetFromJsonAsync<GenreListViewModel>(url);

            return View("List", resposta.Genres);
        }

        // GET: Genres/5
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var url = baseUrl+"/"+id;
            var resposta = await _httpClient.GetFromJsonAsync<GenreViewModel>(url);

            if (resposta == null)
            {
                return NotFound();
            }

            return View(resposta);
        }

        // GET: Genres/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description")] GenreViewModel genre)
        {
            var url = baseUrl;
            var resposta = await _httpClient.PostAsJsonAsync<GenreViewModel>(url, genre);

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
                
            return View(genre);
        }

        // GET: Genres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var url = baseUrl+"/"+id;
            var resposta = await _httpClient.GetFromJsonAsync<GenreViewModel>(url);
            return View(resposta);
        }

        // POST: Genres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description")] GenreViewModel genre)
        {
            if (id != genre.Id)
            {
                return NotFound();
            }

            var url = baseUrl+"/"+id;
            var resposta = await _httpClient.PutAsJsonAsync<GenreViewModel>(url, genre);

            if (resposta.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.ErrorMessage = resposta;
                
            return View(resposta);
        }

        // GET: Genres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var url = baseUrl+"/"+id;
            var resposta = await _httpClient.GetFromJsonAsync<GenreViewModel>(url);

            if (resposta == null)
            {
                return NotFound();
            }

            return View(resposta);
        }

        // POST: Genres/Delete/5
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