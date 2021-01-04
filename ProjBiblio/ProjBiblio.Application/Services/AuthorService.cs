using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ProjBiblio.Application.DTOs;
using ProjBiblio.Application.InputModels;
using ProjBiblio.Application.Interfaces;
using ProjBiblio.Application.ViewModels;
using ProjBiblio.Domain.Entities;
using ProjBiblio.Domain.Interfaces;

namespace ProjBiblio.Application.Services
{
    public class AuthorService : IAuthorService
    {
         private IUnitOfWork _uow;
         private IMapper _mapper;

         public AuthorService(IUnitOfWork uow, IMapper mapper)
         {
             this._uow = uow;
             this._mapper = mapper;
         }

        public AuthorListViewModel Get()
         {
            var authors = this._uow.AuthorRepository.Get();
             return new AuthorListViewModel()
             {
                Authors = _mapper.Map<IEnumerable<AuthorViewModel>>(authors)
             };

         }

         public AuthorViewModel Get(int id)
         {
             var author = this._uow.AuthorRepository.GetById(a => a.AuthorId == id);

            // --esquema Antigo
            // if(author == null)
            //     return null;
            // return new AuthorViewModel()
            // {
            //     Id = author.AuthorId,
            //     Name = author.Name
            // };
            return _mapper.Map<AuthorViewModel>(author);      
        }

        public AuthorViewModel Post(AuthorInputModel authorInputModel)
        {
            var author = _mapper.Map<Author>(authorInputModel);
            _uow.AuthorRepository.Add(author);
            _uow.Commit();

            return _mapper.Map<AuthorViewModel>(author);
        }

        public AuthorViewModel Put(int id, AuthorInputModel authorInputModel)
        {
            var author = _mapper.Map<Author>(authorInputModel);
            _uow.AuthorRepository.Update(author);
            _uow.Commit();

            return _mapper.Map<AuthorViewModel>(author);
        }

        public AuthorViewModel Delete(int id)
        {
            var author = this._uow.AuthorRepository.GetById(a => a.AuthorId == id);
            if(author == null)
                return null;

            _uow.AuthorRepository.Delete(author);
            _uow.Commit();

            return _mapper.Map<AuthorViewModel>(author);
        }

        public IList<AuthorSelectListDto> ListAuthorsByBook(int idBook)
        {
            var authors = this._uow.AuthorRepository.Get().ToList();
            var authorsBook = this._uow.AuthorRepository.GetAuthorsByBook(idBook);

            return (from a in authors
                    select new AuthorSelectListDto
                    {
                        AuthorID = a.AuthorId,
                        Name = a.Name,
                        Selected = authorsBook.Any(la => la.AuthorId == a.AuthorId)
                    }).ToList();
        }
    }
}