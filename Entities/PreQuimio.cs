using BackendOncologia.DTO.AddDTO;
using BackendOncologia.DTO.UpdateDTO;

namespace BackendOncologia.Entities
{
    public class PreQuimio : Entidade
    {
        public string descricao { get; set; }
        public string status { get; set; }
        public ICollection<MedicacaoPreQuimioDetalhe> medicacaoPreQuimioDetalhe { get; set; }
        public ICollection<Protocolos> protocolos { get; set; }
        public PreQuimio() { }
        public PreQuimio(AddPreQuimioDTO addTipoPreQuimioDTO)
        {
            this.descricao = addTipoPreQuimioDTO.descricao;
            this.status = "A";
        }
        public PreQuimio(UpdatePreQuimioDTO updateTipoPreQuimioDTO)
        {
            this.descricao = updateTipoPreQuimioDTO.descricao;
            this.status = updateTipoPreQuimioDTO.status;
            Id = updateTipoPreQuimioDTO.Id;
        }
    }
}
