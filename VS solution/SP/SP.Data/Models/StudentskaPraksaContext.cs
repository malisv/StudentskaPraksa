using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SP.Data.Models
{
    public partial class StudentskaPraksaContext : DbContext
    {
        public StudentskaPraksaContext()
        {
        }

        public StudentskaPraksaContext(DbContextOptions<StudentskaPraksaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DetaljiPraktikanta> DetaljiPraktikantas { get; set; }
        public virtual DbSet<Praktikant> Praktikants { get; set; }
        public virtual DbSet<PraktikantNaVanNastavnojAktivnosti> PraktikantNaVanNastavnojAktivnostis { get; set; }
        public virtual DbSet<StudentskaPraksa> StudentskaPraksas { get; set; }
        public virtual DbSet<VanNastavnaAktivnost> VanNastavnaAktivnosts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=StudentskaPraksa;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<DetaljiPraktikanta>(entity =>
            {
                entity.HasKey(e => e.PraktikantId)
                    .HasName("PK_DETALJIPRAKTIKANTA")
                    .ForSqlServerIsClustered(false);

                entity.ToTable("DetaljiPraktikanta");

                entity.Property(e => e.PraktikantId).ValueGeneratedNever();

                entity.Property(e => e.BrojTelefona)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Praktikant)
                    .WithOne(p => p.DetaljiPraktikanta)
                    .HasForeignKey<DetaljiPraktikanta>(d => d.PraktikantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DETALJIP_DETALJIPR_PRAKTIKA");
            });

            modelBuilder.Entity<Praktikant>(entity =>
            {
                entity.HasKey(e => e.PraktikantId)
                    .HasName("PK_PRAKTIKANT")
                    .ForSqlServerIsClustered(false);

                entity.ToTable("Praktikant");

                entity.HasIndex(e => e.StudentskaPraksaId)
                    .HasName("PraktikantNaPraksi_FK");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.StudentskaPraksa)
                    .WithMany(p => p.Praktikants)
                    .HasForeignKey(d => d.StudentskaPraksaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRAKTIKA_PRAKTIKAN_STUDENTS");
            });

            modelBuilder.Entity<PraktikantNaVanNastavnojAktivnosti>(entity =>
            {
                entity.HasKey(e => new { e.VanNastavnaAktivnostId, e.PraktikantId })
                    .HasName("PK_PRAKTIKANTNAVANNASTAVNOJAKT")
                    .ForSqlServerIsClustered(false);

                entity.ToTable("PraktikantNaVanNastavnojAktivnosti");

                entity.HasIndex(e => e.PraktikantId)
                    .HasName("Relationship_4_FK");

                entity.HasIndex(e => e.VanNastavnaAktivnostId)
                    .HasName("Relationship_5_FK");

                entity.HasOne(d => d.Praktikant)
                    .WithMany(p => p.PraktikantNaVanNastavnojAktivnostis)
                    .HasForeignKey(d => d.PraktikantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRAKTIKA_RELATIONS_PRAKTIKA");

                entity.HasOne(d => d.VanNastavnaAktivnost)
                    .WithMany(p => p.PraktikantNaVanNastavnojAktivnostis)
                    .HasForeignKey(d => d.VanNastavnaAktivnostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRAKTIKA_RELATIONS_VANNASTA");
            });

            modelBuilder.Entity<StudentskaPraksa>(entity =>
            {
                entity.HasKey(e => e.StudentskaPraksaId)
                    .HasName("PK_STUDENTSKAPRAKSA")
                    .ForSqlServerIsClustered(false);

                entity.ToTable("StudentskaPraksa");
            });

            modelBuilder.Entity<VanNastavnaAktivnost>(entity =>
            {
                entity.HasKey(e => e.VanNastavnaAktivnostId)
                    .HasName("PK_VANNASTAVNAAKTIVNOST")
                    .ForSqlServerIsClustered(false);

                entity.ToTable("VanNastavnaAktivnost");

                entity.Property(e => e.Lokacija)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Vrijeme).HasColumnType("datetime");
            });
        }
    }
}
