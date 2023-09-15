using BackendOncologia.Entities;

namespace BackendOncologia.Services
{
    public interface ITokenService
    {
        string GenerateToken(Usuario usuario);
    }

}
