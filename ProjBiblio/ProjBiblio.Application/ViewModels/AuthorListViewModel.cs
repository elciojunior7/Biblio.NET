using System.Collections.Generic;
using ProjBiblio.Domain.Entities;

namespace ProjBiblio.Application.ViewModels
{
    public class AuthorListViewModel
    {
        public IEnumerable<AuthorViewModel> Authors { get; set; }
    }
}