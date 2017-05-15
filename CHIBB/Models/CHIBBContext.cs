using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CHIBB
{
    public partial class CHIBBContext : DbContext
    {
        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<Sensors> Sensors { get; set; }
        public virtual DbSet<Sensorvalues> Sensorvalues { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseNpgsql(@"Host=localhost;Database=CHIBB;Username=postgres;Password=primo1994");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accounts>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK_accounts");

                entity.ToTable("accounts");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasColumnType("varchar")
                    .HasMaxLength(255);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar")
                    .HasMaxLength(255);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasColumnType("varchar")
                    .HasMaxLength(255);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasColumnName("role")
                    .HasColumnType("varchar")
                    .HasMaxLength(255);

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasColumnName("active")
                    .HasColumnType("bool");
            });


            modelBuilder.Entity<Sensors>(entity =>
            {
                entity.HasKey(e => e.Identifier)
                    .HasName("PK_sensors");

                entity.ToTable("sensors");

                entity.Property(e => e.Identifier)
                    .HasColumnName("identifier")
                    .HasColumnType("varchar")
                    .HasMaxLength(255);

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Sensorcomment)
                    .HasColumnName("sensorcomment")
                    .HasColumnType("varchar")
                    .HasMaxLength(255);

                entity.Property(e => e.Sensorname)
                    .HasColumnName("sensorname")
                    .HasColumnType("varchar")
                    .HasMaxLength(255);

                entity.Property(e => e.Sensortype)
                    .HasColumnName("sensortype")
                    .HasColumnType("varchar")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Sensorvalues>(entity =>
            {
                entity.HasKey(e => e.Valuekey)
                    .HasName("PK_sensorvalues");

                entity.ToTable("sensorvalues");

                entity.Property(e => e.Valuekey)
                    .HasColumnName("valuekey")
                    .ValueGeneratedNever();

                entity.Property(e => e.Datadate)
                    .HasColumnName("datadate")
                    .HasColumnType("varchar")
                    .HasMaxLength(255);

                entity.Property(e => e.Identifier)
                    .HasColumnName("identifier")
                    .HasColumnType("varchar")
                    .HasMaxLength(255);

                entity.Property(e => e.Ipadress)
                    .HasColumnName("ipadress")
                    .HasColumnType("varchar")
                    .HasMaxLength(255);

                entity.Property(e => e.Sensordata).HasColumnName("sensordata");

                entity.HasOne(d => d.IdentifierNavigation)
                    .WithMany(p => p.Sensorvalues)
                    .HasForeignKey(d => d.Identifier)
                    .HasConstraintName("sensorvalues_identifier_fkey");
            });
        }
    }
}