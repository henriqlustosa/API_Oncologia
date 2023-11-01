using BackendOncologia.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendOncologia.Configuration
{
    public class ViaDeAdministracaoConfiguration : IEntityTypeConfiguration<ViaDeAdministracao>
    {
        public void Configure(EntityTypeBuilder<ViaDeAdministracao> builder)
        {
            builder.ToTable("ViaDeAdministracao");
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .HasColumnType("INT")
                .UseIdentityColumn();

            builder.Property(u => u.descricao)
                .HasColumnType("VARCHAR(50)");

            builder.Property(u => u.status)
                .HasColumnType("CHAR(1)")
                .IsRequired();

          

          
            builder.HasMany(u => u.medicacaoPreQuimioDetalhe)
                          .WithOne(o => o.viaDeAdministracao)
                          .HasForeignKey(o => o.cod_Usuario)
                          .OnDelete(DeleteBehavior.NoAction);


            builder.HasMany(u => u.protocolos)
                          .WithOne(o => o.viaDeAdministracao)
                          .HasForeignKey(o => o.cod_ViaDeAdministracao)
                          .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
