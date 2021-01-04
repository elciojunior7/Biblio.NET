using ProjBiblio.Application.InputModels;
using ProjBiblio.Application.ViewModels;

namespace ProjBiblio.Application.Interfaces
{
    public interface IUserService
    {
         UserListViewModel Get();

         UserViewModel Post(UserInputModel user);
    }
}