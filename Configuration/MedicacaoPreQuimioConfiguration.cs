using BackendOncologia.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendOncologia.Configuration
{
    public class MedicacaoPreQuimioConfiguration : IEntityTypeConfiguration<MedicacaoPreQuimio>
    {
        public void Configure(EntityTypeBuilder<MedicacaoPreQuimio> builder)
        {
            builder.ToTable("MedicacaoPreQuimio");
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
                          .WithOne(o => o.medicacao)
                          .HasForeignKey(o => o.cod_Medicacao)
                          .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
