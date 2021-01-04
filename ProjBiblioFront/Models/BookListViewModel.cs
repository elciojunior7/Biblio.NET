using System.Collections.Generic;
using ProjBiblioFront.Models;

namespace ProjBiblio.Application.ViewModels
{
    public class BookListViewModel
    {
        public IEnumerable<BookViewModel> Books { get; set; }
    }
}