using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAPI.Senai.OpFlix_Manha.Domains
{
    public partial class OpFlixContext : DbContext
    {
        public OpFlixContext()
        {
        }

        public OpFlixContext(DbContextOptions<OpFlixContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<Plataformas> Plataformas { get; set; }
        public virtual DbSet<Sfs> Sfs { get; set; }
        public virtual DbSet<TiposSf> TiposSf { get; set; }
        public virtual DbSet<TiposUsuarios> TiposUsuarios { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<Favoritos> Favoritos { get; set; }

        // Unable to generate entity type for table 'dbo.Favoritos'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress;Initial Catalog=M_OpFlix_2019;user Id=sa;pwd=132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Favoritos>().HasKey(p => new { p.IdUsuario, p.IdSf });

            modelBuilder.Entity<Favoritos>().HasOne<Usuarios>(sc => sc.Usuario).WithMany(s => s.Favoritos).HasForeignKey(sc => sc.IdUsuario);
            modelBuilder.Entity<Favoritos>().HasOne<Sfs>(sc => sc.SF).WithMany(s => s.Favoritos).HasForeignKey(sc => sc.IdSf);
        
            modelBuilder.Entity<Categorias>(entity =>
            {
                entity.HasKey(e => e.IdCat);

                entity.HasIndex(e => e.NomeCat)
                    .HasName("UQ__Categori__C6627CE8E578ED8D")
                    .IsUnique();

                entity.Property(e => e.NomeCat)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Plataformas>(entity =>
            {
                entity.HasKey(e => e.IdPlataforma);

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__Platafor__7D8FE3B27144829B")
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sfs>(entity =>
            {
                entity.HasKey(e => e.IdSf);

                entity.ToTable("SFs");

                entity.HasIndex(e => e.Titulo)
                    .HasName("Lancamento")
                    .HasFilter("([Titulo]='Indiana Jones')");

                entity.Property(e => e.IdSf).HasColumnName("IdSF");

                entity.Property(e => e.DataLancamento).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .HasColumnType("text")
                    .HasDefaultValueSql("('Sem descrição disponível')");

                entity.Property(e => e.FaixaEtaria).HasDefaultValueSql("((14))");

                entity.Property(e => e.Sinopse)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.TempoD)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCatNavigation)
                    .WithMany(p => p.Sfs)
                    .HasForeignKey(d => d.IdCat)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SFs__IdCat__5DCAEF64");

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.Sfs)
                    .HasForeignKey(d => d.IdTipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SFs__IdTipo__5CD6CB2B");

                entity.HasOne(d => d.PlataformaNavigation)
                    .WithMany(p => p.Sfs)
                    .HasForeignKey(d => d.Plataforma)
                    .HasConstraintName("FK__SFs__Plataforma__75A278F5");
            });

            modelBuilder.Entity<TiposSf>(entity =>
            {
                entity.HasKey(e => e.IdTipo);

                entity.ToTable("TiposSF");

                entity.HasIndex(e => e.DescricaoTipo)
                    .HasName("UQ__TiposSF__CF29975B877511C8")
                    .IsUnique();

                entity.Property(e => e.DescricaoTipo)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TiposUsuarios>(entity =>
            {
                entity.HasKey(e => e.IdTipo);

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__TiposUsu__7D8FE3B24A12C928")
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Usuarios__A9D1053494F8C869")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipo)
                    .HasConstraintName("FK__Usuarios__IdTipo__619B8048");
            });
        }
    }
}
