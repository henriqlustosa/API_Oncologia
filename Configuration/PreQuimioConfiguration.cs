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
                          .WithOne(o => o.preQuimio)
                          .HasForeignKey(o => o.cod_PreQuimio)
                          .OnDelete(DeleteBehavior.Cascade);
          
            builder.HasMany(u => u.protocolos)
                          .WithOne(o => o.preQuimio)
                          .HasForeignKey(o => o.cod_PreQuimio)
                          .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
