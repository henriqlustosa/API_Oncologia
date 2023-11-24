using BackendOncologia.Entities;
using BackendOncologia.Interfaces;

namespace BackendOncologia.Repository
{
    public class MedicacaoRepositoryEF : EFRepository<Medicacao>, IMedicacaoRepository
    {
        public MedicacaoRepositoryEF(ApplicationDbContext context) : base(context)
        {
        }
    }
}
