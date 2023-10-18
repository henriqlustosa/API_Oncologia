using BackendOncologia.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendOncologia.Configuration
{
    public class ProtocolosConfiguration : IEntityTypeConfiguration<Protocolos>
    {
        public void Configure(EntityTypeBuilder<Protocolos> builder)
        {
            builder.ToTable("Protocolos");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnType("INT")
                .UseIdentityColumn();

            builder.Property(p => p.cod_DescricaoProtocolo)
                .HasColumnType("INT");



            builder.Property(p => p.cod_Medicacao)
                .HasColumnType("INT");



            builder.Property(p => p.cod_PreQuimio)
                .HasColumnType("INT");



            builder.Property(p => p.cod_ViaDeAdministracao)
          .HasColumnType("INT");


            builder.Property(p => p.cod_Usuario)
                .HasColumnType("INT");

            builder.Property(p => p.dataCadastro)
                 .HasColumnType("DATETIME");

            builder.Property(p => p.status)
                .HasColumnType("CHAR(1)");


            builder.Property(p => p.dose)
              .HasColumnType("INT");

            builder.Property(p => p.unidadeDose)
                .HasColumnType("VARCHAR(50)")
                .IsRequired();

            builder.Property(p => p.diluicao)
               .HasColumnType("VARCHAR(50)")
               .IsRequired();

            builder.Property(p => p.tempoDeInfusao)
              .HasColumnType("VARCHAR(50)");

            builder.Property(p => p.unidadeTempoDeInfusao)
                .HasColumnType("VARCHAR(10)");



           

            builder.HasOne(o => o.medicacao)
                .WithMany(p => p.protocolos)
                .HasPrincipalKey(p => p.Id);

            builder.HasOne(u => u.preQuimio)
              .WithMany(p => p.protocolos)
              .HasPrincipalKey(u => u.Id);


            builder.HasOne(u => u.viaDeAdministracao)
              .WithMany(p => p.protocolos)
              .HasPrincipalKey(u => u.Id);


            builder.HasOne(u => u.usuario)
              .WithMany(p => p.protocolos)
              .HasPrincipalKey(u => u.Id);


           

        }
    }
}
