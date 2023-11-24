using BackendOncologia.Entities;

namespace BackendOncologia.DTO.UpdateDTO
{
    public class UpdateProtocolosDTO
    {
        public int Id { get; set; }
        public int cod_DescricaoProtocolo { get; set; }
        public int cod_Medicacao { get; set; }
        public int cod_PreQuimio { get; set; }
        public int cod_ViaDeAdministracao { get; set; }
        public string nome_Usuario { get; set; }
      

        public DateTime dataCadastro { get; set; }

        public string status { get; set; }

        public int dose { get; set; }

        public string unidadeDose { get; set; }

        public string diluicao { get; set; }

        public string tempoDeInfusao { get; set; }
        public string unidadeTempoDeInfusao { get; set; }
    }
}
