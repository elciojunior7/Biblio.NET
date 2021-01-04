using System.Collections.Generic;
using ProjBiblio.Domain.Entities;

namespace ProjBiblio.Domain.Interfaces
{
    public interface IKartRepository : IRepository<Kart>
    {
         IEnumerable<Kart> GetKartBySessionId(string idSession);
    }
}