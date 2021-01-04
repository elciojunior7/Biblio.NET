using System.Collections.Generic;
using ProjBiblio.Application.DTOs;
using ProjBiblio.Application.InputModels;
using ProjBiblio.Application.ViewModels;

namespace ProjBiblio.Application.Interfaces
{
    public interface IAuthorService
    {
         AuthorListViewModel Get();
         AuthorViewModel Get(int id);
         AuthorViewModel Post(AuthorInputModel author);
         AuthorViewModel Put(int id, AuthorInputModel author);
         AuthorViewModel Delete(int id);
        IList<AuthorSelectListDto> ListAuthorsByBook(int idLivro);
    }
}