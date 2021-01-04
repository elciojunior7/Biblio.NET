namespace ProjBiblio.Application.ViewModels
{
    public class KartViewModel
    {
        public long Id { get; set; }
        public int? LoanId { get; set; }

        public string SessionUserID { get; set; }

        // Normalizar posteriormente em uma tabela CarrinhoItem
        public int BookId { get; set; }

        public string BookName { get; set; }

        public int BookAmount { get; set; }
    }
}