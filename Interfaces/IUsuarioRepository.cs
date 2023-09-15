using BackendOncologia.Entities;

namespace BackendOncologia.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario ObterUsuarioPorNomeDoUsuarioSenha(string NomeUsuario, string password);
    }
}
