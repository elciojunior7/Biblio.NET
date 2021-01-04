using ProjBiblio.Application.InputModels;
using ProjBiblio.Application.ViewModels;

namespace ProjBiblio.Application.Interfaces
{
    public interface IKartService
    {
        KartListViewModel GetBySession(string sessionId);

        KartViewModel Post(KartInputModel autor);

        KartViewModel Delete(int id);
    }
}