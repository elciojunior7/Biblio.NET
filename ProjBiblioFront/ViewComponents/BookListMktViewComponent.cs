using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjBiblioFront.Models;

namespace ProjBiblioFront.ViewComponents
{
    public class BookListMktViewComponent : ViewComponent
    {
        private readonly HttpClient _httpClient;

        public BookListMktViewComponent(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IViewComponentResult> InvokeAsync(int mktId)
        {
            var list = await GetItemsAsync(mktId);
            return View(list);
        }
        
        private async Task<List<BookSelectListDto>> GetItemsAsync(int mktId)
        {
            var url = $"/v1/Books/listbooksmkt/{mktId}";
            return await _httpClient.GetFromJsonAsync<List<BookSelectListDto>>(url);
        }
    }
}