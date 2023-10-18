using BackendOncologia.Entities;
using BackendOncologia.Interfaces;

namespace BackendOncologia.Repository
{
    public class ProtocolosRepositoryEF : EFRepository<Protocolos>, IProtocolosRepository
    {
        public ProtocolosRepositoryEF(ApplicationDbContext context) : base(context)
        {
        }
    }
}
