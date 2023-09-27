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


    }
}
