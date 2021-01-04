using System.Collections.Generic;
using AutoMapper;
using ProjBiblio.Application.InputModels;
using ProjBiblio.Application.Interfaces;
using ProjBiblio.Application.ViewModels;
using ProjBiblio.Domain.Entities;
using ProjBiblio.Domain.Interfaces;

namespace ProjBiblio.Application.Services
{
    public class UserService : IUserService
    {
         public IUnitOfWork _uow;

        public IMapper _mapper;

        public UserService(IUnitOfWork uow, IMapper mapper)
        {
            this._uow = uow;
            this._mapper = mapper;
        }

         public UserListViewModel Get()
         {
             var users = this._uow.UserRepository.Get();

            return new UserListViewModel()
            {
                Users = _mapper.Map<IEnumerable<UserViewModel>>(users)
            };
         }

         public UserViewModel Post(UserInputModel userInputModel)
        {
            var user = _mapper.Map<User>(userInputModel);

            _uow.UserRepository.Add(user);
            _uow.Commit();

            return _mapper.Map<UserViewModel>(user);
        }
    }
}