using System.Collections.Generic;
using AutoMapper;
using ProjBiblio.Application.InputModels;
using ProjBiblio.Application.Interfaces;
using ProjBiblio.Application.ViewModels;
using ProjBiblio.Domain.Entities;
using ProjBiblio.Domain.Interfaces;

namespace ProjBiblio.Application.Services
{
    public class GenreService : IGenreService
    {
         private IUnitOfWork _uow;
         private IMapper _mapper;

         public GenreService(IUnitOfWork uow, IMapper mapper)
         {
             this._uow = uow;
             this._mapper = mapper;
         }

         public GenreListViewModel Get()
         {
             var genres = this._uow.GenreRepository.Get();
             return new GenreListViewModel()
             {
                Genres = _mapper.Map<IEnumerable<GenreViewModel>>(genres)
             };
         }

         public GenreViewModel Get(int id)
         {
            var genre = this._uow.GenreRepository.GetById(a => a.GenreID == id);
            return _mapper.Map<GenreViewModel>(genre);      
        }

        public GenreViewModel Post(GenreInputModel genreInputModel)
        {
            var genre = _mapper.Map<Genre>(genreInputModel);
            _uow.GenreRepository.Add(genre);
            _uow.Commit();

            return _mapper.Map<GenreViewModel>(genre);
        }

        public GenreViewModel Put(int id, GenreInputModel genreInputModel)
        {
            var genre = _mapper.Map<Genre>(genreInputModel);
            _uow.GenreRepository.Update(genre);
            _uow.Commit();

            return _mapper.Map<GenreViewModel>(genre);
        }

        public GenreViewModel Delete(int id)
        {
            var genre = this._uow.GenreRepository.GetById(a => a.GenreID == id);
            if(genre == null)
                return null;

            _uow.GenreRepository.Delete(genre);
            _uow.Commit();

            return _mapper.Map<GenreViewModel>(genre);
        }
    }
}