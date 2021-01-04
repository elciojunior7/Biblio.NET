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
    public class LoansController : ControllerBase
    {
        private ILoanService _loanService;

        public LoansController(ILoanService loanService)
        {
            this._loanService = loanService;
        }

        [HttpGet("{id}", Name="GetLoan")]
        public ActionResult<LoanListViewModel> Get(int id) 
        { 
            var result = _loanService.GetByUser(id);

            if (result == null)
                return NotFound();

            return result;
        }

        [HttpGet("Details/{id}", Name="GetLoanDetails")]
        public ActionResult<LoanViewModel> Details(int id) 
        { 
            var result = _loanService.GetLoanDetails(id);

            if (result == null)
                return NotFound();

            return result;
        }

        [HttpPost]
        public ActionResult Post([FromBody] LoanInputModel loan)
        {
            var result = _loanService.CreateLoan(loan);

            return new CreatedAtRouteResult("GetLoanDetails", 
                new { id = result.Id }, result);
        }

        [HttpPost("ReturnBooks/{id}")]
        public ActionResult ReturnBooks(int id, [FromBody] LoanInputModel loan)
        {
            if (id != loan.Id)
                return BadRequest();           

            var result = _loanService.ReturnBooks(loan.Id);

            return new CreatedAtRouteResult("GetLoanDetails", 
                new { id = result.Id }, result);
        }
    }
}