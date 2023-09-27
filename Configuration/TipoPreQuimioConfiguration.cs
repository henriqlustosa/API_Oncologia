using BackendOncologia.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendOncologia.Configuration
{
    public class TipoPreQuimioConfiguration : IEntityTypeConfiguration<TipoPreQuimio>
    {
        public void Configure(EntityTypeBuilder<TipoPreQuimio> builder)
        {
            builder.ToTable("TipoPreQuimio");
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .HasColumnType("INT")
                .UseIdentityColumn();

            builder.Property(u => u.descricao)
                .HasColumnType("VARCHAR(50)");

            builder.Property(u => u.status)
                .HasColumnType("CHAR(1)")
                .IsRequired();




            builder.HasMany(u => u.preQuimios)
                          .WithOne(o => o.tipoPreQuimio)
                          .HasForeignKey(o => o.cod_TipoPreQuimio)
                          .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
