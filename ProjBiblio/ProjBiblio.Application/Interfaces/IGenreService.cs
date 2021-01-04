using ProjBiblio.Application.InputModels;
using ProjBiblio.Application.ViewModels;

namespace ProjBiblio.Application.Interfaces
{
    public interface IGenreService
    {
        GenreListViewModel Get();
         GenreViewModel Get(int id);
         GenreViewModel Post(GenreInputModel genre);
         GenreViewModel Put(int id, GenreInputModel genre);
         GenreViewModel Delete(int id);
    }
}