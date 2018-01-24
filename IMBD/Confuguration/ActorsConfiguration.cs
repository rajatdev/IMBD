using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMBD.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace IMBD.Confuguration
{
    public class ActorsConfiguration : EntityTypeConfiguration<Actors>
    {
        public ActorsConfiguration()
        {
            this.ToTable("Actors");
         //   this.HasKey<int>(s => s.Id);
            this.Property(p => p.Name).HasColumnName("Name");
            this.Property(p => p.Sex).HasColumnName("Sex");
            this.Property(p => p.Dob).HasColumnName("Dob");
            this.Property(p => p.Bio).HasColumnName("Bio");
            

        }
    }
}