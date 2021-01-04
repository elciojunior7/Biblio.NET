using System.Collections.Generic;

namespace ProjBiblioFront.Models
{
    public class AuthorListViewModel
    {
        public IEnumerable<AuthorViewModel> Authors { get; set; }
    }
}