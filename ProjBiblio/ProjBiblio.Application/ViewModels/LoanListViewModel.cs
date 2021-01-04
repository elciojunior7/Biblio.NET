using System.Collections.Generic;

namespace ProjBiblio.Application.ViewModels
{
    public class LoanListViewModel
    {
        public IEnumerable<LoanViewModel> Loans { get; set; }
    }
}