using BackendOncologia.DTO;

namespace BackendOncologia.Entities
{
    public class MedicacaoPreQuimio : Entidade
    {
        public string descricao { get; set; }
        public string status { get; set; }

        public ICollection<PreQuimio> preQuimios { get; set; }

        public MedicacaoPreQuimio() { }
        public MedicacaoPreQuimio(AddMedicacaoPreQuimioDTO addMedicacaoPreQuimioDTO)
        {
            this.descricao = addMedicacaoPreQuimioDTO.descricao;
        }
        public MedicacaoPreQuimio(UpdateMedicacaoPreQuimioDTO updateMedicacaoPreQuimioDTO)
        {
            this.descricao = updateMedicacaoPreQuimioDTO.descricao;
            this.status = updateMedicacaoPreQuimioDTO.status;
        }
    }
}
