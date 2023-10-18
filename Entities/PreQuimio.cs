using BackendOncologia.DTO.AddDTO;
using BackendOncologia.DTO.UpdateDTO;
using BackendOncologia.Enums;

namespace BackendOncologia.Entities
{
    public class PreQuimio : Entidade
    {
        public int cod_TipoPreQuimio { get; set; }
        public int cod_Medicacao { get; set; }
        public int cod_Quimio { get; set; }
        public int cod_ViaDeAdministracao { get; set; }
        public int cod_Usuario { get; set; }
        public TipoPreQuimio tipoPreQuimio { get; set; }

        public MedicacaoPreQuimio medicacao { get; set; }
        public int quantidade { get; set; }

        public string unidadeQuantidade { get; set; }

        public Quimio quimio { get; set; }

        public ViaDeAdministracao viaDeAdministracao { get;set; }
        public string diluicao { get; set; }

        public int tempoDeInfusao { get; set; }
        public string unidadeTempoDeInfusao { get; set; }

        public DateTime dataCadastro { get; set; }

        public Usuario usuario { get; set; }
        
        public string status {  get; set; }
        public ICollection<Protocolos> protocolos { get; set; }
        public PreQuimio() { }
        public PreQuimio(AddPreQuimioDTO addTipoQuimioDTO)
        {
            this.cod_TipoPreQuimio = addTipoQuimioDTO.cod_TipoPreQuimio;
            this.cod_Medicacao = addTipoQuimioDTO.cod_Medicacao;
            this.cod_Quimio = addTipoQuimioDTO.cod_Quimio;
            this.cod_ViaDeAdministracao = addTipoQuimioDTO.cod_ViaDeAdministracao;
            this.cod_Usuario = addTipoQuimioDTO.cod_Usuario;
            this.quantidade = addTipoQuimioDTO.quantidade;
            this.unidadeQuantidade = addTipoQuimioDTO.unidadeQuantidade;
            this.diluicao = addTipoQuimioDTO.diluicao;
            this.tempoDeInfusao = addTipoQuimioDTO.tempoDeInfusao;
            this.unidadeTempoDeInfusao = addTipoQuimioDTO.unidadeTempoDeInfusao;
            this.dataCadastro = addTipoQuimioDTO.dataCadastro;
            this.status = addTipoQuimioDTO.status;
    }
        public PreQuimio(UpdatePreQuimioDTO updatePreQuimioDTO)
        {
            this.cod_TipoPreQuimio = updatePreQuimioDTO.cod_TipoPreQuimio;
            this.cod_Medicacao = updatePreQuimioDTO.cod_Medicacao;
            this.cod_Quimio = updatePreQuimioDTO.cod_Quimio;
            this.cod_ViaDeAdministracao = updatePreQuimioDTO.cod_ViaDeAdministracao;
            this.cod_Usuario = updatePreQuimioDTO.cod_Usuario;
            this.quantidade = updatePreQuimioDTO.quantidade;
            this.unidadeQuantidade = updatePreQuimioDTO.unidadeQuantidade;
            this.diluicao = updatePreQuimioDTO.diluicao;
            this.tempoDeInfusao = updatePreQuimioDTO.tempoDeInfusao;
            this.unidadeTempoDeInfusao = updatePreQuimioDTO.unidadeTempoDeInfusao;
            this.dataCadastro = updatePreQuimioDTO.dataCadastro;
            this.status = updatePreQuimioDTO.status;
            Id = updatePreQuimioDTO.Id;
        }
    }
}
