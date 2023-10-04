using BackendOncologia.Entities;
using BackendOncologia.Interfaces;

namespace BackendOncologia.Repository
{
    public class MedicacaoPreQuimioRepositoryEF : EFRepository<MedicacaoPreQuimio>, IMedicacaoPreQuimioRepository
    {
        public MedicacaoPreQuimioRepositoryEF(ApplicationDbContext context) : base(context)
        {
        }
    }
}
