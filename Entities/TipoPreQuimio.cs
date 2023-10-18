using BackendOncologia.DTO.AddDTO;
using BackendOncologia.DTO.UpdateDTO;

namespace BackendOncologia.Entities
{
    public class TipoPreQuimio : Entidade
    {
        public string descricao { get; set; }
        public string status { get; set; }
        public ICollection<PreQuimio> preQuimios { get; set; }

        public TipoPreQuimio() { }
        public TipoPreQuimio(AddTipoPreQuimioDTO addTipoPreQuimioDTO)
        {
            this.descricao = addTipoPreQuimioDTO.descricao;
            this.status = "A";
        }
        public TipoPreQuimio(UpdateTipoPreQuimioDTO updateTipoPreQuimioDTO)
        {
            this.descricao = updateTipoPreQuimioDTO.descricao;
            this.status = updateTipoPreQuimioDTO.status;
            Id = updateTipoPreQuimioDTO.Id;
        }
    }
}
