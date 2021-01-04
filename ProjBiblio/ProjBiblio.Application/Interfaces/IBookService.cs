using System.Collections.Generic;
using ProjBiblio.Application.DTOs;
using ProjBiblio.Application.InputModels;
using ProjBiblio.Application.ViewModels;

namespace ProjBiblio.Application.Interfaces
{
    public interface IBookService
    {
         BookListViewModel Get();
         BookViewModel Get(int id);
         BookViewModel Post(BookInputModel book);
         BookViewModel Put(int id, BookInputModel book);
         BookViewModel Delete(int id);
         IList<BookSelectListDto> ListBooksByMkt(int idMkt);
    }
}