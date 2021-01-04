using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjBiblioFront.Models;

namespace ProjBiblioFront.Controllers
{
    public class LoansController : Controller
    {
        private readonly ILogger<LoansController> _logger;
        private readonly HttpClient _httpClient;
        private readonly string baseUrl = $"/v1/Loans";

        public LoansController(ILogger<LoansController> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        // // GET: Loans
        public async Task<IActionResult> Index()
        {
            var usuarioId = 1; // Fixo por enquanto

            var url = baseUrl+ "/" + usuarioId;
            var resposta = await _httpClient.GetFromJsonAsync<LoanListViewModel>(url);

            return View("List", resposta.Loans);
        }

        // // GET: Loans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var url = baseUrl+"/Details/"+id;
            var emprestimo = await _httpClient.GetFromJsonAsync<LoanViewModel>(url);

            if (emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);
        }

        public async Task<IActionResult> ReturnBooks(int? id)
        {
            if (id == null)
                return NotFound();

            var emprestimo = new LoanInputModel()
            {
                Id = id.Value
            };
            
            var url = baseUrl+"/ReturnBooks/"+id;
            var result = await _httpClient.PostAsJsonAsync(url, emprestimo);

            if (!result.IsSuccessStatusCode)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}