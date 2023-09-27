using BackendOncologia.DTO;
using BackendOncologia.Enums;

namespace BackendOncologia.Entities
{
    public class Usuario : Entidade
    {

        public string Nome { get; set; }
        public string NomeUsuario { get; set;}
        
        public string Senha { get; set;}
        public TipoPermissao Permissao { get; set;}

        public ICollection<PreQuimio> PreQuimios { get; set; }

        public Usuario() { }

        public Usuario(AddUsuarioDTO addUserDTO) 
        {
            Nome = addUserDTO.Nome;
            NomeUsuario = addUserDTO.NomeUsuario;
            Senha = addUserDTO.Senha;
            Permissao = addUserDTO.Permissao;
        }
        public Usuario(UpdateUsuarioDTO updateUsuarioDTO) 
        { 
            Nome = updateUsuarioDTO.NomeUsuario;
            Id = updateUsuarioDTO.Id;
        
        
        
        }

      
    }
}
