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
    public class BookService : IBookService
    {
         private IUnitOfWork _uow;
         private IMapper _mapper;

         public BookService(IUnitOfWork uow, IMapper mapper)
         {
             this._uow = uow;
             this._mapper = mapper;
         }

        public BookListViewModel Get()
         {
            var books = this._uow.BookRepository.Get();
             return new BookListViewModel()
             {
                Books = _mapper.Map<IEnumerable<BookViewModel>>(books)
             };
         }

        public BookViewModel Get(int id)
        {
            var book = this._uow.BookRepository.GetById(b => b.BookId == id);
            return _mapper.Map<BookViewModel>(book);
        }

        public BookViewModel Post(BookInputModel bookInputModel)
        {
            var book = _mapper.Map<Book>(bookInputModel);
            _uow.BookRepository.Add(book);
            _uow.Commit();

            return _mapper.Map<BookViewModel>(book);
        }

        public BookViewModel Put(int id, BookInputModel bookInputModel)
        {
            //-- antigo
            // var book = _mapper.Map<Book>(bookInputModel);
            // _uow.BookRepository.Update(book);
            // _uow.Commit();

            _uow.BookRepository.DeleteBooksAuthor(id);
            _uow.Commit();

            var book = _mapper.Map<Book>(bookInputModel);

            foreach (var a in book.BoAuthors) {
                a.Books = book;
            }

            _uow.BookRepository.Update(book);
            _uow.Commit();

            return _mapper.Map<BookViewModel>(book);
        }

        public BookViewModel Delete(int id)
        {
            var book = this._uow.BookRepository.GetById(b => b.BookId == id);
            if (book == null)
            {
                return null;
            }

            _uow.BookRepository.Delete(book);
            _uow.Commit();

            return _mapper.Map<BookViewModel>(book);
        }

        public IList<BookSelectListDto> ListBooksByMkt(int idMkt)
        {
            var books = this._uow.BookRepository.Get().ToList();
            var booksMkt = this._uow.BookRepository.GetBooksByMkt(idMkt);

            return (from b in books
                    select new BookSelectListDto
                    {
                        BookID = b.BookId,
                        Title = b.Title,
                        Selected = booksMkt.Any(bm => bm.BookId == b.BookId)
                    }).ToList();
        }
    }
}