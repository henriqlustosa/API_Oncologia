using BackendOncologia.Enums;

namespace BackendOncologia.DTO
{
    public class AddUsuarioDTO
    {
        public string Nome { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
        public TipoPermissao Permissao { get; set; }
    }
}
