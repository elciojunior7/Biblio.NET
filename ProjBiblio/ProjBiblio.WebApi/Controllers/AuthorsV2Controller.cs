using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProjBiblio.Application.DTOs;
using ProjBiblio.Application.InputModels;
using ProjBiblio.Application.Interfaces;
using ProjBiblio.Application.ViewModels;

namespace ProjBiblio.WebApi.Controllers
{
    [ApiController]
    [ApiVersion( "2" )]
    [Route("v{version:apiVersion}/Authors")]

    public class AuthorsV2Controller : ControllerBase
    {
        private IAuthorService _authorService;

        public AuthorsV2Controller(IAuthorService authorService)
        {
            this._authorService = authorService;
        }

        [HttpGet]
        [MapToApiVersion( "2" )]
        public AuthorListViewModel Get()
        {
            var authorList = _authorService.Get();
            authorList.Authors = authorList.Authors.OrderBy(a => a.Name);
            return authorList;
        }
    }
}