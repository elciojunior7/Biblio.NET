using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ProjBiblio.Application.InputModels;
using ProjBiblio.Application.Interfaces;
using ProjBiblio.Application.ViewModels;
using ProjBiblio.Domain.Entities;
using ProjBiblio.Domain.Interfaces;

namespace ProjBiblio.Application.Services
{
    public class LoanService : ILoanService
    {
        public IUnitOfWork _uow;
        public IMapper _mapper;

        public LoanService(IUnitOfWork uow, IMapper mapper)
        {
            this._uow = uow;
            this._mapper = mapper;
        }

        public LoanListViewModel GetByUser(int usuarioId)
        {
            var loan = this._uow.LoanRepository.GetLoanByUser(usuarioId);

            return new LoanListViewModel()
            {
                Loans =  _mapper.Map<IEnumerable<LoanViewModel>>(loan)
            };
        }

        public LoanViewModel GetLoanDetails(int loanId)
        {
            var loan = this._uow.LoanRepository.GetLoanInclude(loanId);            

            var loanViewModel = _mapper.Map<LoanViewModel>(loan);

            foreach(var books in loan.BoLoan)
            {
                loanViewModel.Books.Add(
                    _mapper.Map<BookViewModel>(books.Books)                
                );
            }

            return loanViewModel;
        }

        public LoanViewModel CreateLoan(LoanInputModel loanInputModel)
        {
            var kart = this._uow.KartRepository.GetKartBySessionId(loanInputModel.SessionUserId).ToList();

            var loan = new Loan()
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(7),
                ReturnDate = null,
                UserID = GetUser()
            };

            foreach (var c in kart)
                loan.BoLoan.Add(new BookLoan() { BookID = c.BookID });
            
            _uow.LoanRepository.Add(loan);
            _uow.Commit();

            foreach (var c in kart) 
            {
                c.LoanID = loan.LoanID;
                _uow.KartRepository.Update(c);
                _uow.Commit();
            }

            return _mapper.Map<LoanViewModel>(loan);
        }

        public LoanViewModel ReturnBooks(int loanId)
        {
            var loan = _uow.LoanRepository.GetById(e => e.LoanID == loanId);

            loan.ReturnDate = DateTime.Now;
            
            _uow.LoanRepository.Update(loan);
            _uow.Commit();

            return _mapper.Map<LoanViewModel>(loan);
        }

        private int GetUser()
        {
            var usuario = _uow.UserRepository.Get().FirstOrDefault();

            if (usuario == null)
            {
                usuario = new User() { Name = "User Teste" };
                _uow.UserRepository.Add(usuario);
                _uow.Commit();
            }

            return usuario.UserId;
        }
        
    }
}