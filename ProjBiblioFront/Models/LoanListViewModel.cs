using System.Collections.Generic;

namespace ProjBiblioFront.Models
{
    public class LoanListViewModel
    {
        public IEnumerable<LoanViewModel> Loans { get; set; }
    }
}