using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using IMBD.Models;

namespace IMBD.Confuguration
{
    public class Retrieve : DbContext
    {
        public Retrieve() : base("Data Source=LAPTOP-AC4IQ5T2;Initial Catalog=IMDB;Integrated Security=True")
        {
        }
        public DbSet<Actors> Actors { get; set; }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Producers> Producers { get; set; }
        public DbSet<Actor_Movies> Actor_Movies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure default schema
            modelBuilder.HasDefaultSchema("Admin");

            //Map entity to table
            modelBuilder.Entity<Actors>().ToTable("Actors");
            modelBuilder.Entity<Movies>().ToTable("Movies");
            modelBuilder.Entity<Producers>().ToTable("Producers");
            modelBuilder.Entity<Actor_Movies>().ToTable("Actor_Movies");

        }

    }
}