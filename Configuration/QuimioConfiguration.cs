using BackendOncologia.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BackendOncologia.Configuration
{
    public class QuimioConfiguration : IEntityTypeConfiguration<Quimio>
    {
        public void Configure(EntityTypeBuilder<Quimio> builder)
        {
            builder.ToTable("Quimio");
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
                          .WithOne(o => o.quimio)
                          .HasForeignKey(o => o.cod_Quimio)
                          .OnDelete(DeleteBehavior.NoAction);


            

        }
    }
}
