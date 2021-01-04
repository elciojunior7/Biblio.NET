using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjBiblioFront.Models;

namespace ProjBiblioFront.ViewComponents
{
    public class AuthorListViewComponent : ViewComponent
    {
        private readonly HttpClient _httpClient;

        public AuthorListViewComponent(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IViewComponentResult> InvokeAsync(int bookId)
        {
            var items = await GetItemsAsync(bookId);
            return View(items);
        }
        
        private async Task<List<AuthorSelectListDto>> GetItemsAsync(int bookId)
        {
            var url = $"/v1/Authors/listauthorsbook/{bookId}";
            return await _httpClient.GetFromJsonAsync<List<AuthorSelectListDto>>(url);
        }
    }
}