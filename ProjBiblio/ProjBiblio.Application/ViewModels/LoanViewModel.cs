using System;
using System.Collections.Generic;

namespace ProjBiblio.Application.ViewModels
{
    public class LoanViewModel
    {
        public int Id { get; set; }

        public int UserID { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        public ICollection<BookViewModel> Books { get; set; }

        public LoanViewModel()
        {
            Books = new List<BookViewModel>();
        }
    }
}