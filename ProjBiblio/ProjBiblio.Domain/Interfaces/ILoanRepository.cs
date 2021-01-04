using System.Collections.Generic;
using ProjBiblio.Domain.Entities;

namespace ProjBiblio.Domain.Interfaces
{
    public interface ILoanRepository: IRepository<Loan>
    {
        IEnumerable<Loan> GetLoanByUser(int userId);

        Loan GetLoanInclude(int loanId);
    }
}