using BackendOncologia.Entities;
using BackendOncologia.Interfaces;

namespace BackendOncologia.Repository
{
    public class TipoPreQuimioRepositoryEF : EFRepository<PreQuimio>, ITipoPreQuimioRepository
    {
        public TipoPreQuimioRepositoryEF(ApplicationDbContext context) : base(context)
        {
        }
    }
}
