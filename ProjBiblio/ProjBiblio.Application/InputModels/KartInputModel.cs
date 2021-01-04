using System;

namespace ProjBiblio.Application.InputModels
{
    public class KartInputModel
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }

        public int? LoanId { get; set; }

        public string SessionUserID { get; set; }

        // Normalizar posteriormente em uma tabela CarrinhoItem
        public int BookID { get; set; }

        public int BookAmount { get; set; }
        
    }
}