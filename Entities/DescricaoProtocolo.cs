using BackendOncologia.DTO.AddDTO;
using BackendOncologia.DTO.UpdateDTO;

namespace BackendOncologia.Entities
{
    public class DescricaoProtocolo : Entidade
    {
        public string descricao { get; set; }
        public string status { get; set; }
        public ICollection<Protocolos> protocolos { get; set; }

        public DescricaoProtocolo() { }
        public DescricaoProtocolo(AddDescricaoProtocoloDTO addDescricaoProtocoloDTO)
        {
            this.descricao = addDescricaoProtocoloDTO.descricao;
            this.status = "A";
        }
        public DescricaoProtocolo(UpdateDescricaoProtocoloDTO updateDescricaoProtocoloDTO)
        {
            this.descricao = updateDescricaoProtocoloDTO.descricao;
            this.status = updateDescricaoProtocoloDTO.status;
            Id = updateDescricaoProtocoloDTO.Id;
        }
    }
}
