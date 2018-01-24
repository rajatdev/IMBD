using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMBD.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace IMBD.Confuguration
{
    public class MoviesConfiguration : EntityTypeConfiguration<Movies>
    {
        public MoviesConfiguration()
        {
            this.ToTable("Movies");
            this.HasKey<int>(s => s.Id);
            this.Property(p => p.Name).HasColumnName("Name");
            this.Property(p => p.Plot).HasColumnName("Plot");
            this.Property(p => p.PosterId).HasColumnName("PosterId");
            this.Property(p => p.ProducerId).HasColumnName("ProducerId");
            this.Property(p => p.ReleaseDate).HasColumnName("ReleaseDate");
            this.HasKey(e => e.Id);

            this.HasMany(c => c.Actor_movie)
               .WithRequired()
               .HasForeignKey(c => c.MovieId);
              this.HasRequired(s => s.producer);

        }
    }
}