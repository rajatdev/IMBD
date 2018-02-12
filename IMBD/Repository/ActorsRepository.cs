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
        public static ImdbConfiguration _context;

        public ActorsRepository()
        {
            _context = new ImdbConfiguration();
        }

        public List<Actors> ListActors()
        {
            return _context.Actors.ToList();
        }
        public int AddActor(Actors actor)
        {
            _context.Actors.Add(actor);
            _context.SaveChanges();
            return actor.Id;
        }
        public void DeleteActor(int id)
        {
            var actor = new Actors { Id = id };
            _context.Actors.Attach(actor);
            _context.Actors.Remove(actor);
            _context.SaveChanges();
        }
    }
}