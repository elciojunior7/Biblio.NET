using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjBiblioFront.Models;

namespace ProjBiblioFront.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly ILogger<AuthorsController> _logger;
        private readonly HttpClient _httpClient;
        private readonly string baseUrl = $"/v1/Authors";

        public AuthorsController(ILogger<AuthorsController> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        // GET: Authors
        public async Task<IActionResult> Index()
        {
            var url = baseUrl;
            var resposta = await _httpClient.GetFromJsonAsync<AuthorListViewModel>(url);

            return View("List", resposta.Authors);
        }

        // GET: Authors/5
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var url = baseUrl+"/"+id;
            var resposta = await _httpClient.GetFromJsonAsync<AuthorViewModel>(url);

            if (resposta == null)
            {
                return NotFound();
            }

            return View(resposta);
        }

        // GET: Authors/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] AuthorViewModel autor)
        {
            var url = baseUrl;
            var resposta = await _httpClient.PostAsJsonAsync<AuthorViewModel>(url, autor);

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
                
            return View(autor);
        }

        // GET: Authors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var url = baseUrl+"/"+id;
            var resposta = await _httpClient.GetFromJsonAsync<AuthorViewModel>(url);
            return View(resposta);
        }

        // POST: Authors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] AuthorViewModel autor)
        {
            if (id != autor.Id)
            {
                return NotFound();
            }

            var url = baseUrl+"/"+id;
            var resposta = await _httpClient.PutAsJsonAsync<AuthorViewModel>(url, autor);

            if (resposta.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.ErrorMessage = resposta;
                
            return View(resposta);
        }

        // GET: Authors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var url = baseUrl+"/"+id;
            var resposta = await _httpClient.GetFromJsonAsync<AuthorViewModel>(url);

            if (resposta == null)
            {
                return NotFound();
            }

            return View(resposta);
        }

        // POST: Authors/Delete/5
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