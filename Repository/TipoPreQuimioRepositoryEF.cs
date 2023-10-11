using BackendOncologia.Entities;
using BackendOncologia.Interfaces;

namespace BackendOncologia.Repository
{
    public class TipoPreQuimioRepositoryEF : EFRepository<TipoPreQuimio>, ITipoPreQuimioRepository
    {
        public TipoPreQuimioRepositoryEF(ApplicationDbContext context) : base(context)
        {
        }
    }
}
