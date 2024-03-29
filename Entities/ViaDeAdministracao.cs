﻿using BackendOncologia.DTO.AddDTO;
using BackendOncologia.DTO.UpdateDTO;

namespace BackendOncologia.Entities
{
    public class ViaDeAdministracao : Entidade
    {
        public string descricao { get; set; }
        public string status { get; set; }
        public ICollection<MedicacaoPreQuimioDetalhe> medicacaoPreQuimioDetalhe { get; set; }
        public ICollection<Protocolos> protocolos { get; set; }
        public ViaDeAdministracao() { }
        public ViaDeAdministracao(AddViaDeAdministracaoDTO addViaDeAdministracaoDTO)
        {
            this.descricao = addViaDeAdministracaoDTO.descricao;
            this.status = "A";
        }
        public ViaDeAdministracao(UpdateViaDeAdministracaoDTO updateViaDeAdministracaoDTO)
        {
            this.descricao = updateViaDeAdministracaoDTO.descricao;
            this.status = updateViaDeAdministracaoDTO.status;
            Id = updateViaDeAdministracaoDTO.Id;
        }
    }
}
