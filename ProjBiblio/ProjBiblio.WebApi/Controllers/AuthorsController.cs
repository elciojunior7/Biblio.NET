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
    [Route("v{version:apiVersion}/Authors")]
    [Produces("application/json")]
    public class AuthorsController : ControllerBase
    {
        private IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            this._authorService = authorService;
        }

        [HttpGet]
        [MapToApiVersion( "1" )]
        public AuthorListViewModel Get()
        {
            return _authorService.Get();
        }

        [HttpGet("{id}", Name="GetAuthorsDetails")]
        public ActionResult<AuthorViewModel> Get(int id)
        {
            var result = _authorService.Get(id);
            if (result == null)
                return NotFound();
            return _authorService.Get(id);
        }

        /// <summary>
        /// Add a new Author (inclui um novo Autor)
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        /// 
        ///     {
        ///         "id" : 0,
        ///         "name": "Novo Autor"
        ///     }
        /// 
        /// </remarks>
        /// <param name="author"> objeto AuthorInputModel</param>
        /// <returns>objeto autor incluído</returns>
        /// <remarks>retorna um objeto autor incluído</remarks>
        [HttpPost]
        public ActionResult Post([FromBody] AuthorInputModel author)
        {
            var result = _authorService.Post(author);
            return new CreatedAtRouteResult("GetAuthorsDetails", new {id = result.Id}, result);
        }

        [HttpDelete("{id}")]
        public ActionResult<AuthorViewModel> Delete(int id)
        {
            var result = _authorService.Delete(id);
            if(result == null)
            {
                return NotFound();
            }
            return result;
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] AuthorInputModel author)
        {
            if(id != author.Id)
            {
                return BadRequest();
            }
            var result = _authorService.Put(id, author);
            return new CreatedAtRouteResult("GetAuthorsDetails", new {id = result.Id}, result);
        }

        [HttpGet("listauthorsbook/{id}")]
        public IList<AuthorSelectListDto> ListAuthorsByBook(int id)
        {
            var result = _authorService.ListAuthorsByBook(id);

            return result;
        }

    }
}