using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CHIBB
{
    public partial class CHIBBContext : DbContext
    {
        public virtual DbSet<Sensors> Sensors { get; set; }
        public virtual DbSet<Sensorvalues> Sensorvalues { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseNpgsql(@"Host=localhost;Database=project;Username=postgres;Password=Rivva");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sensors>(entity =>
            {
                entity.HasKey(e => e.Identifier)
                    .HasName("PK_sensors");

                entity.ToTable("sensors");

                entity.Property(e => e.Identifier)
                    .HasColumnName("identifier")
                    .HasColumnType("varchar")
                    .HasMaxLength(255);

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

                entity.Property(e => e.Valuekey).HasColumnName("valuekey");

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