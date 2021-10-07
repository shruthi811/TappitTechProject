using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.IO;

#nullable disable

namespace TappitTechnicalTest.Models​
{
    public partial class tappit_dbContext : DbContext
    {
        public tappit_dbContext()
        {
        }

        public tappit_dbContext(DbContextOptions<tappit_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FavouriteSport> FavouriteSports { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Sport> Sports { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<FavouriteSport>(entity =>
            {
                entity.HasKey(e => new { e.PersonId, e.SportId });

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.FavouriteSports)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FavouriteSports_People");

                entity.HasOne(d => d.Sport)
                    .WithMany(p => p.FavouriteSports)
                    .HasForeignKey(d => d.SportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FavouriteSports_Sports");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.PersonId).ValueGeneratedNever();

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);
            });

            modelBuilder.Entity<Sport>(entity =>
            {
                entity.Property(e => e.SportId).ValueGeneratedNever();

                entity.Property(e => e.Name).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
