using BackendOncologia.DTO.AddDTO;
using BackendOncologia.DTO.UpdateDTO;
using BackendOncologia.Enums;

namespace BackendOncologia.Entities
{
    public class Protocolos: Entidade
    {
        public int cod_DescricaoProtocolo { get; set; }
        public int cod_Medicacao { get; set; }
        public int cod_PreQuimio { get; set; }
        public int cod_ViaDeAdministracao { get; set; }
        public string nome_Usuario { get; set; }
        public DescricaoProtocolo descricaoProtocolo { get; set; }

        public Medicacao medicacao { get; set; }
        
        public PreQuimio preQuimio { get; set; }
        public ViaDeAdministracao viaDeAdministracao { get; set; }

        //public Usuario usuario { get; set; }

        public DateTime dataCadastro { get; set; }

        public string status { get; set; }

        public int dose { get; set; }

        public string  unidadeDose { get; set; }

        public string diluicao { get; set; }

        public string tempoDeInfusao { get; set; }
        public string unidadeTempoDeInfusao { get; set; }







        public Protocolos() { }
    


        public Protocolos(AddProtocolosDTO addProtocolosDTO)
        {
            this.cod_DescricaoProtocolo = addProtocolosDTO.cod_DescricaoProtocolo;
            this.cod_Medicacao = addProtocolosDTO.cod_Medicacao;
            this.cod_PreQuimio = addProtocolosDTO.cod_PreQuimio;
            this.cod_ViaDeAdministracao = addProtocolosDTO.cod_ViaDeAdministracao;
            this.nome_Usuario = addProtocolosDTO.nome_Usuario;
            this.dataCadastro = addProtocolosDTO.dataCadastro;
            this.status = addProtocolosDTO.status;
            this.dose = addProtocolosDTO.dose;
            this.unidadeDose = addProtocolosDTO.unidadeDose;
            this.diluicao = addProtocolosDTO.diluicao;
            this.tempoDeInfusao = addProtocolosDTO.tempoDeInfusao;
            this.unidadeTempoDeInfusao = addProtocolosDTO.unidadeTempoDeInfusao;
        }
        public Protocolos(UpdateProtocolosDTO updateProtocolosDTO)
        {
            this.cod_DescricaoProtocolo = updateProtocolosDTO.cod_DescricaoProtocolo;
            this.cod_Medicacao = updateProtocolosDTO.cod_Medicacao;
            this.cod_PreQuimio = updateProtocolosDTO.cod_PreQuimio;
            this.cod_ViaDeAdministracao = updateProtocolosDTO.cod_ViaDeAdministracao;
            this.nome_Usuario = updateProtocolosDTO.nome_Usuario;
            this.dataCadastro = updateProtocolosDTO.dataCadastro;
            this.status = updateProtocolosDTO.status;
            this.dose = updateProtocolosDTO.dose;
            this.unidadeDose = updateProtocolosDTO.unidadeDose;
            this.diluicao = updateProtocolosDTO.diluicao;
            this.tempoDeInfusao = updateProtocolosDTO.tempoDeInfusao;
            this.unidadeTempoDeInfusao = updateProtocolosDTO.unidadeTempoDeInfusao;
            Id = updateProtocolosDTO.Id;
        }
    }
}
