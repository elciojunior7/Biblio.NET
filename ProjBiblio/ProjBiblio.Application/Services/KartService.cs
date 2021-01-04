using System.Collections.Generic;
using AutoMapper;
using ProjBiblio.Application.InputModels;
using ProjBiblio.Application.Interfaces;
using ProjBiblio.Application.ViewModels;
using ProjBiblio.Domain.Entities;
using ProjBiblio.Domain.Interfaces;

namespace ProjBiblio.Application.Services
{
    public class KartService : IKartService
    {
        public IUnitOfWork _uow;
        public IMapper _mapper;

        public KartService(IUnitOfWork uow, IMapper mapper)
        {
            this._uow = uow;
            this._mapper = mapper;
        }

        public KartListViewModel GetBySession(string sessionId)
        {
            var books = this._uow.KartRepository.GetKartBySessionId(sessionId);

            return new KartListViewModel()
            {
                Items =  _mapper.Map<IEnumerable<KartViewModel>>(books)
            };

            // return new KartListViewModel()
            // {
            //     Items = (from l in books.ToList()
            //                 select new KartViewModel
            //                 {
            //                     EmprestimoID = l.EmprestimoID,
            //                     LivroID = l.LivroID,
            //                     NomeLivro = l.Livro.Titulo,
            //                     Quantidade = l.Quantidade,
            //                     SessionUserID = l.SessionUserID
            //                 }).ToList()
            // };
        }

        public KartViewModel Delete(int id)
        {
            var kart = this._uow.KartRepository.GetById(a => a.KartID == id);

            if (kart == null)
            {
                return null;
            }

            _uow.KartRepository.Delete(kart);
            _uow.Commit();

            return _mapper.Map<KartViewModel>(kart);
        }

        public KartViewModel Post(KartInputModel kartInputModel)
        {
            var kart = _mapper.Map<Kart>(kartInputModel);

            _uow.KartRepository.Add(kart);
            _uow.Commit();

            return _mapper.Map<KartViewModel>(kart);
        }
    }
}