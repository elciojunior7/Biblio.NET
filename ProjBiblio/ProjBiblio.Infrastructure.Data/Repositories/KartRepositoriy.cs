using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProjBiblio.Domain.Entities;
using ProjBiblio.Domain.Interfaces;
using ProjBiblio.Infrastructure.Data.Context;

namespace ProjBiblio.Infrastructure.Data.Repositories
{
    public class KartRepository : Repository<Kart>, IKartRepository {
        public KartRepository (BiblioDbContext context) : base (context) { }

        public IEnumerable<Kart> GetKartBySessionId (string idSession) {
            return _context.Kart.AsNoTracking ()
                .Include (c => c.Books)
                .Where (c => c.SessionUserID == idSession);
        }
    }
}