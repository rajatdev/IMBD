using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMBD.Models;
using IMBD.Interfaces;
using IMBD.Confuguration;


namespace IMBD.Repository
{
    public class ActorsRepository:IActors
    {
        public static ImdbConfiguration context;

        public ActorsRepository()
        {
            context = new ImdbConfiguration();
        }

        public List<Actors> ListActors()
        {
            return context.Actors.ToList();
        }
        public void AddActor(Actors actor)
        {
            string b=actor.Bio;
        }
    }
}