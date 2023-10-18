using BackendOncologia.Entities;
using BackendOncologia.Interfaces;

namespace BackendOncologia.Repository
{
    public class DescricaoProtocoloRepositoryEF : EFRepository<DescricaoProtocolo>, IDescricaoProtocoloRepository
    {
        public DescricaoProtocoloRepositoryEF(ApplicationDbContext context) : base(context)
        {
        }
    }
}
