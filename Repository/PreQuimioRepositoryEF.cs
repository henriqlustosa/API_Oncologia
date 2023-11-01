using BackendOncologia.Entities;
using BackendOncologia.Interfaces;

namespace BackendOncologia.Repository
{
    public class PreQuimioRepositoryEF : EFRepository<MedicacaoPreQuimioDetalhe>, IPreQuimioRepository
    {
        public PreQuimioRepositoryEF(ApplicationDbContext context) : base(context)
        {
        }
    }
}
