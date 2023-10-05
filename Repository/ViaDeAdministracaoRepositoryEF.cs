using BackendOncologia.Entities;
using BackendOncologia.Interfaces;

namespace BackendOncologia.Repository
{
    public class ViaDeAdministracaoRepositoryEF : EFRepository<ViaDeAdministracao>, IViaDeAdministracaoRepository
    {
        public ViaDeAdministracaoRepositoryEF(ApplicationDbContext context) : base(context)
        {
        }
    }
}
