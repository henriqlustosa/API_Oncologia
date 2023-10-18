using BackendOncologia.Enums;

namespace BackendOncologia.DTO.UpdateDTO
{
    public class UpdateUsuarioDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeUsuario { get; set; }

        public string Senha { get; set; }
        public TipoPermissao Permissao { get; set; }
    }
}
