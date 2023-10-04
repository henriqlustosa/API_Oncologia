using BackendOncologia.DTO;

namespace BackendOncologia.Entities
{
    public class ViaDeAdministracao : Entidade
    {
        public string descricao { get; set; }
        public string status { get; set; }
        public ICollection<PreQuimio> preQuimios { get; set; }

        public ViaDeAdministracao(AddViaDeAdministracaoDTO addViaDeAdministracaoDTO)
        {
            this.descricao = addViaDeAdministracaoDTO.descricao;
        }
        public ViaDeAdministracao(UpdateViaDeAdministracaoDTO updateViaDeAdministracaoDTO)
        {
            this.descricao = updateViaDeAdministracaoDTO.descricao;
            this.status = updateViaDeAdministracaoDTO.status;
        }
    }
}
