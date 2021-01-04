using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjBiblio.Application.ViewModels;
using ProjBiblioFront.Models;

namespace ProjBiblioFront.Controllers
{
    public class BooksController : Controller
    {
        private HttpClient _httpClient;
        private readonly ILogger<BooksController> _logger;
        private readonly string baseUrl = $"/v1/Books";

         public BooksController(ILogger<BooksController> logger, HttpClient httpClient)
        {
            this._logger = logger;
            this._httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var url = baseUrl;
            var resposta = await _httpClient.GetFromJsonAsync<BookListViewModel>(url);

            return View("List", resposta.Books);
        }

        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var url = baseUrl+"/"+id;
            var resposta = await _httpClient.GetFromJsonAsync<BookViewModel>(url);

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
        public async Task<IActionResult> Create([Bind("Id,Title,Amount,Photo,Year,Edition,Pages,Publisher,GenreID")] BookViewModel book,
            string[] selectedAuthors)
        {
            if (selectedAuthors != null)
            {
                book.Authors = new List<AuthorSelectListDto>();

                foreach (var idAutor in selectedAuthors)
                    book.Authors.Add(new AuthorSelectListDto() { AuthorID = int.Parse(idAutor), Selected = true });
            }

            var url = baseUrl;
            var resposta = await _httpClient.PostAsJsonAsync<BookViewModel>(url, book);

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
                
            return View(book);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var url = baseUrl+"/"+id;
            var resposta = await _httpClient.GetFromJsonAsync<BookViewModel>(url);
            return View(resposta);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Amount,Photo,Year,Edition,Pages,Publisher,GenreID")] BookViewModel book,
            string[] selectedAuthors)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (selectedAuthors != null)
            {
                book.Authors = new List<AuthorSelectListDto>();

                foreach (var idAutor in selectedAuthors)
                    book.Authors.Add(new AuthorSelectListDto() { AuthorID = int.Parse(idAutor), Selected = true });
            }

            var url = baseUrl+"/"+id;
            var resposta = await _httpClient.PutAsJsonAsync<BookViewModel>(url, book);

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
            var resposta = await _httpClient.GetFromJsonAsync<BookViewModel>(url);

            if (resposta == null)
            {
                return NotFound();
            }

            return View(resposta);
        }

        // POST: Books/Delete/5
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