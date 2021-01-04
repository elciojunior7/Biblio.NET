using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProjBiblio.Application.DTOs;
using ProjBiblio.Application.InputModels;
using ProjBiblio.Application.Interfaces;
using ProjBiblio.Application.ViewModels;

namespace ProjBiblio.WebApi.Controllers
{
    [ApiController]
    [ApiVersion( "1" )]
    [ApiVersion( "2" )]
    [Route("v{version:apiVersion}/Books")]
    [Produces("application/json")]
    public class BooksController : ControllerBase
    {
        private IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            this._bookService = bookService;
        }

        [HttpGet]
        public BookListViewModel Get()
        {
            return _bookService.Get();
        }

        [HttpGet("{id}", Name="GetBooksDetails")]
        public ActionResult<BookViewModel> Get(int id)
        {
            var result = _bookService.Get(id);
            if (result == null)
                return NotFound();
            return _bookService.Get(id);
        }

        [HttpPost]
        public ActionResult Post([FromBody] BookInputModel book)
        {
            var result = _bookService.Post(book);
            return new CreatedAtRouteResult("GetBooksDetails", new {id = result.Id}, result);
        }

        [HttpDelete("{id}")]
        public ActionResult<BookViewModel> Delete(int id)
        {
            var result = _bookService.Delete(id);
            if(result == null)
            {
                return NotFound();
            }
            return result;
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] BookInputModel book)
        {
            if(id != book.Id)
            {
                return BadRequest();
            }
            var result = _bookService.Put(id, book);
            return new CreatedAtRouteResult("GetBooksDetails", new {id = result.Id}, result);
        }

        [HttpGet("listbooksmkt/{id}")]
        public IList<BookSelectListDto> ListBooksByMkt(int id)
        {
            var result = _bookService.ListBooksByMkt(id);

            return result;
        }
    }
}