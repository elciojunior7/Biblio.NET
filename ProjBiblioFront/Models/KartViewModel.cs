namespace ProjBiblioFront.Models
{
    public class KartViewModel
    {
        public long Id { get; set; }
        public int? LoanID { get; set; }

        public string SessionUserID { get; set; }

        // Dados do livro desnormalizados
        public int BookId { get; set; }

        public string BookName { get; set; }

        public int BookAmount { get; set; }
    }
}