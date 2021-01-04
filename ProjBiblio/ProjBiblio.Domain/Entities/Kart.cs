using System;

namespace ProjBiblio.Domain.Entities
{
    public class Kart
    {
        public long KartID { get; set; }

        public DateTime Date { get; set; }

        public int? LoanID { get; set; }

        public string SessionUserID { get; set; }

        // Normalizar posteriormente em uma tabela CarrinhoItem
        public int BookID { get; set; }

        public virtual Book Books { get; set; }

        public int Amount { get; set; }
    }
}