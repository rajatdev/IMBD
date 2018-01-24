using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMBD.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace IMBD.Confuguration
{
    public class Actor_MoviesConfiguration : EntityTypeConfiguration<Actor_Movies>
    {
        public Actor_MoviesConfiguration()
        {
            this.ToTable("Actor_Movies");
            this.HasKey<int>(s => s.Id);
            this.Property(p => p.Id).HasColumnName("Id");
            this.Property(p => p.ActorId).HasColumnName("ActorId");
            this.Property(p => p.MovieId).HasColumnName("MovieId");
        }
    }
}