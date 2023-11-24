using BackendOncologia.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace BackendOncologia.Configuration
{

    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .HasColumnType("INT")
                .UseIdentityColumn();

            builder.Property(u => u.Nome)
                .HasColumnType("VARCHAR(100)");

            builder.Property(u => u.NomeUsuario)
                .HasColumnType("VARCHAR(50)")
                .IsRequired();

            builder.Property(u => u.Senha)
                .HasColumnType("VARCHAR(50)")
                .IsRequired();

            builder.Property(u => u.Permissao)
                .HasConversion<int>()
                .IsRequired();

            //builder.HasMany(u => u.medicacaoPreQuimioDetalhe)
            //              .WithOne(o => o.usuario)
            //              .HasForeignKey(o => o.cod_Usuario)
            //              .OnDelete(DeleteBehavior.NoAction);

            //builder.HasMany(u => u.protocolos)
            //              .WithOne(o => o.usuario)
            //              .HasForeignKey(o => o.cod_Usuario)
            //              .OnDelete(DeleteBehavior.NoAction);

        }
    }

}
