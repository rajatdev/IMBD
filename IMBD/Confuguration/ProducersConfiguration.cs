using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMBD.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace IMBD.Confuguration
{
    public class ProducersConfiguration : EntityTypeConfiguration<Producers>
    {
        public ProducersConfiguration()
        {
            this.ToTable("Producers");
            this.HasKey<int>(s => s.Id);
            this.Property(p => p.Id).HasColumnName("Id");
            this.Property(p => p.Name).HasColumnName("Name");
            this.Property(p => p.Sex).HasColumnName("Sex");
            this.Property(p => p.Dob).HasColumnName("Dob");
            this.Property(p => p.Bio).HasColumnName("Bio");

        }
    }
}