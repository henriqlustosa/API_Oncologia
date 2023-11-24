using BackendOncologia.DTO.AddDTO;
using BackendOncologia.DTO.UpdateDTO;

namespace BackendOncologia.Entities
{
    public class Quimio : Entidade
    {
        public string descricao { get; set; }
        public string status { get; set; }
        
        public ICollection<MedicacaoPreQuimioDetalhe> medicacaoPreQuimioDetalhe { get; set; }

        public Quimio() { }
        public Quimio(AddQuimioDTO addQuimioDTO)
        {
            this.descricao = addQuimioDTO.descricao;
            this.status = "A";
        }
        public Quimio(UpdateQuimioDTO updateQuimioDTO)
        {
            this.descricao = updateQuimioDTO.descricao;
            this.status = updateQuimioDTO.status;
            Id = updateQuimioDTO.Id;
        }   
    }
}
