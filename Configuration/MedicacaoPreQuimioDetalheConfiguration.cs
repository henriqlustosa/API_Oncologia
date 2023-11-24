using BackendOncologia.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendOncologia.Configuration
{
    public class MedicacaoPreQuimioDetalheConfiguration : IEntityTypeConfiguration<MedicacaoPreQuimioDetalhe>
    {

        public void Configure(EntityTypeBuilder<MedicacaoPreQuimioDetalhe> builder)
        {
            builder.ToTable("MedicacaoPreQuimioDetalhe");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnType("INT")
                .UseIdentityColumn();

            builder.Property(p => p.cod_PreQuimio)
                .HasColumnType("INT");



            builder.Property(p => p.cod_Medicacao)
                .HasColumnType("INT");



            builder.Property(p => p.cod_Quimio)
                .HasColumnType("INT");



            builder.Property(p => p.cod_ViaDeAdministracao)
          .HasColumnType("INT");

            builder.Property(p => p.nome_Usuario)
               .HasColumnType("VARCHAR(50)")
               .IsRequired();

            builder.Property(p => p.quantidade)
                .HasColumnType("INT");

            builder.Property(p => p.unidadeQuantidade)
                .HasColumnType("VARCHAR(10)")
                .IsRequired();
           

            builder.Property(p => p.diluicao)
               .HasColumnType("VARCHAR(50)")
               .IsRequired();

            builder.Property(p => p.tempoDeInfusao)
              .HasColumnType("INT");

            builder.Property(p => p.unidadeTempoDeInfusao)
                .HasColumnType("VARCHAR(10)");


            builder.Property(p => p.dataCadastro)
                 .HasColumnType("DATETIME");

            builder.Property(p => p.status)
                 .HasColumnType("CHAR(1)");

            builder.HasOne(o => o.preQuimio)
                .WithMany(p => p.medicacaoPreQuimioDetalhe)
                .HasPrincipalKey(p => p.Id);

            //builder.HasOne(u => u.usuario)
            //  .WithMany(p => p.medicacaoPreQuimioDetalhe)
            //  .HasPrincipalKey(u => u.Id);


            builder.HasOne(u => u.medicacaoPreQuimio)
              .WithMany(p => p.medicacaoPreQuimioDetalhe)
              .HasPrincipalKey(u => u.Id);


            builder.HasOne(u => u.viaDeAdministracao)
              .WithMany(p => p.medicacaoPreQuimioDetalhe)
              .HasPrincipalKey(u => u.Id);

       

        }
    }
}
