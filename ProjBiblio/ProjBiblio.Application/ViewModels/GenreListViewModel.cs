using System.Collections.Generic;

namespace ProjBiblio.Application.ViewModels
{
    public class GenreListViewModel
    {
        public IEnumerable<GenreViewModel> Genres { get; set; }
    }
}