namespace ProjBiblio.Domain.Entities
{
    public class BookLoan
    {
        public int BookID { get; set; }
        public Book Books { get; set; }
        public int LoanID { get; set; }
        public Loan Loans { get; set; }
    }
}