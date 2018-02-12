using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMBD.Models;
using IMBD.Interfaces;
using IMBD.Confuguration;


namespace IMBD.Repository
{
    public class Actor_MoviesRepository:IActor_Movies
    {
        public static ImdbConfiguration context;

        public Actor_MoviesRepository()
        {
            context = new ImdbConfiguration();
        }

        public List<Actor_Movies> ListActor_Movies()
        {
            return context.Actor_Movies.ToList();
        }

        public void Add(Actor_Movies actor_movie)
        {
            context.Actor_Movies.Add(actor_movie);
            context.SaveChanges();
        }
    }
}