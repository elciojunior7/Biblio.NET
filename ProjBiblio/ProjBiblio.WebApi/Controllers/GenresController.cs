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
    public class GenresController : ControllerBase
    {
        private IGenreService _genreService;

        public GenresController(IGenreService genreService)
        {
            this._genreService = genreService;
        }

        [HttpGet]
        public GenreListViewModel Get()
        {
            return _genreService.Get();
        }

        [HttpGet("{id}", Name="GetGenresDetails")]
        public ActionResult<GenreViewModel> Get(int id)
        {
            var result = _genreService.Get(id);
            if (result == null)
                return NotFound();
            return _genreService.Get(id);
        }

        public ActionResult Post([FromBody] GenreInputModel genre)
        {
            var result = _genreService.Post(genre);
            return new CreatedAtRouteResult("GetGenresDetails", new {id = result.Id}, result);
        }

        [HttpDelete("{id}")]
        public ActionResult<GenreViewModel> Delete(int id)
        {
            var result = _genreService.Delete(id);
            if(result == null)
            {
                return NotFound();
            }
            return result;
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] GenreInputModel genre)
        {
            if(id != genre.Id)
            {
                return BadRequest();
            }
            var result = _genreService.Put(id, genre);
            return new CreatedAtRouteResult("GetGenresDetails", new {id = result.Id}, result);
        }

    }
}