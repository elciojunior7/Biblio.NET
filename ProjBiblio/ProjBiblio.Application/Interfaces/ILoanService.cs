using ProjBiblio.Application.InputModels;
using ProjBiblio.Application.ViewModels;

namespace ProjBiblio.Application.Interfaces
{
    public interface ILoanService
    {
        LoanListViewModel GetByUser(int userId);

        LoanViewModel GetLoanDetails(int loanId);

        LoanViewModel CreateLoan(LoanInputModel loan);

        LoanViewModel ReturnBooks(int loanId);
    }
}