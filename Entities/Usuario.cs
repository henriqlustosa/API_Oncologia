using BackendOncologia.DTO.AddDTO;
using BackendOncologia.DTO.UpdateDTO;
using BackendOncologia.Enums;

namespace BackendOncologia.Entities
{
    public class Usuario : Entidade
    {

        public string Nome { get; set; }
        public string NomeUsuario { get; set;}
        
        public string Senha { get; set;}
        public TipoPermissao Permissao { get; set;}

        public ICollection<MedicacaoPreQuimioDetalhe> medicacaoPreQuimioDetalhe { get; set; }
        public ICollection<Protocolos> protocolos { get; set; }

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
            Nome = updateUsuarioDTO.Nome;
            NomeUsuario = updateUsuarioDTO.NomeUsuario;
            Senha = updateUsuarioDTO.Senha;
            Permissao = updateUsuarioDTO.Permissao;
            Id = updateUsuarioDTO.Id;
        }



    }

      
}

