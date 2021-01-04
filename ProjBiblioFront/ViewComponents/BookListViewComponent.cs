using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjBiblio.Application.ViewModels;
using ProjBiblioFront.Models;

namespace ProjBiblioFront.ViewComponents
{
    public class BookListViewComponent : ViewComponent
    {
        private readonly HttpClient _httpClient;

        public BookListViewComponent(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var books = await GetBookListAsync();
            return View(books);
        }

        private async Task<IEnumerable<BookViewModel>> GetBookListAsync()
        {
            var url = $"/v1/Books";
            var resposta = await _httpClient.GetFromJsonAsync<BookListViewModel>(url);

            return resposta.Books;
        }
    }
}