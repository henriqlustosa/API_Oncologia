namespace BackendOncologia.DTO.UpdateDTO
{
    public class UpdatePreQuimioDTO
    {
        public int Id { get; set; }
        public int cod_TipoPreQuimio { get; set; }
        public int cod_Medicacao { get; set; }
        public int cod_Quimio { get; set; }
        public int cod_ViaDeAdministracao { get; set; }
        public int cod_Usuario { get; set; }

        public int quantidade { get; set; }

        public string unidadeQuantidade { get; set; }



        public string diluicao { get; set; }

        public int tempoDeInfusao { get; set; }
        public string unidadeTempoDeInfusao { get; set; }

        public DateTime dataCadastro { get; set; }



        public string status { get; set; }
    }
}
