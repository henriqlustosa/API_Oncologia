using BackendOncologia.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendOncologia.Configuration
{
    public class PreQuimioConfiguration : IEntityTypeConfiguration<PreQuimio>
    {

        public void Configure(EntityTypeBuilder<PreQuimio> builder)
        {
            builder.ToTable("PreQuimio");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnType("INT")
                .UseIdentityColumn();

            builder.Property(p => p.cod_TipoPreQuimio)
                .HasColumnType("INT");



            builder.Property(p => p.cod_Medicacao)
                .HasColumnType("INT");



            builder.Property(p => p.cod_Quimio)
                .HasColumnType("INT");



            builder.Property(p => p.cod_ViaDeAdministracao)
          .HasColumnType("INT");
         

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

            builder.HasOne(o => o.tipoPreQuimio)
                .WithMany(p => p.preQuimios)
                .HasPrincipalKey(p => p.Id);

            builder.HasOne(u => u.usuario)
              .WithMany(p => p.PreQuimios)
              .HasPrincipalKey(u => u.Id);


            builder.HasOne(u => u.medicacao)
              .WithMany(p => p.preQuimios)
              .HasPrincipalKey(u => u.Id);


            builder.HasOne(u => u.viaDeAdministracao)
              .WithMany(p => p.preQuimios)
              .HasPrincipalKey(u => u.Id);


            builder.HasMany(u => u.protocolos)
                          .WithOne(o => o.preQuimio)
                          .HasForeignKey(o => o.cod_PreQuimio)
                          .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
