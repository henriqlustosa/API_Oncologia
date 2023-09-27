namespace BackendOncologia.Entities
{
    public class TipoPreQuimio : Entidade
    {
        public string descricao { get; set; }
        public string status { get; set; }
        public ICollection<PreQuimio> preQuimios { get; set; }
    }
}
