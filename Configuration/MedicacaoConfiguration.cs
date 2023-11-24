using BackendOncologia.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BackendOncologia.Configuration
{
    public class MedicacaoConfiguration : IEntityTypeConfiguration<Medicacao>
    {

        public void Configure(EntityTypeBuilder<Medicacao> builder)
        {
            builder.ToTable("Medicacao");
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .HasColumnType("INT")
                .UseIdentityColumn();

            builder.Property(u => u.descricao)
                .HasColumnType("VARCHAR(50)");

            builder.Property(u => u.status)
                .HasColumnType("CHAR(1)")
                .IsRequired();




            builder.HasMany(u => u.protocolos)
                          .WithOne(o => o.medicacao)
                          .HasForeignKey(o => o.cod_Medicacao)
                          .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
