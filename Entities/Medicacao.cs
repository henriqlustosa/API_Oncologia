using BackendOncologia.DTO.AddDTO;
using BackendOncologia.DTO.UpdateDTO;

namespace BackendOncologia.Entities
{
    public class Medicacao : Entidade
    {

        public string descricao { get; set; }
        public string status { get; set; }

        public ICollection<Protocolos> protocolos { get; set; }

        public Medicacao() { }
        public Medicacao(AddMedicacaoDTO addMedicacaoDTO)
        {
            this.descricao = addMedicacaoDTO.descricao;
            this.status = "A";
        }
        public Medicacao(UpdateMedicacoDTO updateMedicacaoDTO)
        {
            this.descricao = updateMedicacaoDTO.descricao;
            this.status = updateMedicacaoDTO.status;
            Id = updateMedicacaoDTO.Id;
        }
    }
}
