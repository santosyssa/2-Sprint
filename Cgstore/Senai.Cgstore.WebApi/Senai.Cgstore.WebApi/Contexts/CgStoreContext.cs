using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.Cgstore.WebApi.Domains
{
    public partial class CgStoreContext : DbContext
    {
        public CgStoreContext()
        {
        }

        public CgStoreContext(DbContextOptions<CgStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<Permissoes> Permissoes { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress; Initial Catalog=T_CgStore;User Id=sa;Pwd=132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorias>(entity =>
            {
                entity.HasKey(e => e.CategoriaId);

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__Categori__7D8FE3B2F515E29B")
                    .IsUnique();

                entity.Property(e => e.DataCriacao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Categorias)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("FK__Categoria__Usuar__52593CB8");
            });

            modelBuilder.Entity<Permissoes>(entity =>
            {
                entity.HasKey(e => e.PermissaoId);

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__Permisso__7D8FE3B2D7543361")
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.UsuarioId);

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Usuarios__A9D105345A27C3CE")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Permissao)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.PermissaoId)
                    .HasConstraintName("FK__Usuarios__Permis__4D94879B");
            });
        }
    }
}
