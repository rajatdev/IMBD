using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using IMBD.Models;

namespace IMBD.Confuguration
{
    public class ImdbConfiguration : DbContext
    {
        public ImdbConfiguration() : base("Data Source=LAPTOP-AC4IQ5T2;Initial Catalog=IMDB;Integrated Security=True")
        {
        }
        public DbSet<Actors> Actors { get; set; }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Producers> Producers { get; set; }
        public DbSet<Actor_Movies> Actor_Movies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure default schema
            //modelBuilder.HasDefaultSchema("Admin");
            modelBuilder.Configurations.Add(new ActorsConfiguration());
            modelBuilder.Configurations.Add(new Actor_MoviesConfiguration());
            modelBuilder.Configurations.Add(new MoviesConfiguration());
            modelBuilder.Configurations.Add(new ProducersConfiguration());


            //Map entity to table
            modelBuilder.Entity<Actors>().ToTable("Actors");

            modelBuilder.Entity<Movies>().ToTable("Movies");
            modelBuilder.Entity<Producers>().ToTable("Producers");
            modelBuilder.Entity<Actor_Movies>().ToTable("Actor_Movies");



            /*    modelBuilder.Entity<Movies>()
                    .HasMany<Actor_Movies>(s => s.Actor_movie)
                    .WithMany(c => c.movie);*/

           


            // modelBuilder.Entity<Actor_Movies>().HasKey(e => e.ActorId);

       /*     modelBuilder.Entity<Actor_Movies>()
              .HasMany(c => c.Actors)
              .WithRequired()
              .HasForeignKey(c => c.Id);

            /* modelBuilder.Entity<Actor_Movies>()
               .HasMany(c => c.actor)
               .WithRequired()
               .HasForeignKey(c => c.Id);
             /*   modelBuilder.Entity<Actor_Movies>()
                .HasKey(e => e.Id);

                modelBuilder.Entity<Actor_Movies>()
               .HasMany(e => e.actor)
               .WithRequired()
               .HasForeignKey(c => c.Id);*/




            //foreign key
            // modelBuilder.Entity<Movies>().HasMany<Actor_Movies>(s => s.Id);
        }

    }

}