using BackendOncologia.Entities;
using BackendOncologia.Interfaces;

namespace BackendOncologia.Repository
{
    public class QuimioRepositoryEF : EFRepository<Quimio>, IQuimioRepository
    {
        public QuimioRepositoryEF(ApplicationDbContext context) : base(context)
        {
        }
    }
}
