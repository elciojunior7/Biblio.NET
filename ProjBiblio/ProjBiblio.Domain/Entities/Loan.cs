using System;
using System.Collections.Generic;

namespace ProjBiblio.Domain.Entities
{
    public class Loan
    {
        public int LoanID { get; set; }
        public int UserID { get; set; }
        public virtual User Users { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public ICollection<BookLoan> BoLoan { get; set; }
        public Loan()
        {
            BoLoan = new List<BookLoan>();
        }
    }
}