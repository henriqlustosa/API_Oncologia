using BackendOncologia.Entities;
using BackendOncologia.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackendOncologia.Repository
{
    public class UsuarioRepositoryEF :EFRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepositoryEF(ApplicationDbContext context) : base(context)
        {
        }
        public Usuario ObterUsuarioPorNomeDoUsuarioSenha(string userName, string password)
        {
            return _context.Usuario.FirstOrDefault(u => u.NomeUsuario == userName && u.Senha == password);
        }
    }
}
