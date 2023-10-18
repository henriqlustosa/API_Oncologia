using BackendOncologia.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendOncologia.Configuration
{
    public class DescricaoProtocoloConfiguration : IEntityTypeConfiguration<DescricaoProtocolo>
    {
        public void Configure(EntityTypeBuilder<DescricaoProtocolo> builder)
        {
            builder.ToTable("DescricaoProtocolo");
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
                              .WithOne(o => o.descricaoProtocolo)
                              .HasForeignKey(o => o.cod_DescricaoProtocolo)
                              .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
