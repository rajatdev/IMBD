using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMBD.Models;
using IMBD.Interfaces;
using IMBD.Confuguration;

namespace IMBD.Repository
{
    public class ProducersRepository:IProducers
    {
        static ImdbConfiguration _context=new ImdbConfiguration();
        public ProducersRepository()
        {
            //_context = new ImdbConfiguration();
        }

        public List<Producers> ListProducers()
        {
            return _context.Producers.ToList();
        }
        public int AddProducer(Producers producer)
        {
            _context.Producers.Add(producer);
            _context.SaveChanges();
            return producer.Id;
        }
        public void DeleteProducer(int id)
        {
            var producer = new Producers { Id = id };
            _context.Producers.Attach(producer);
            _context.Producers.Remove(producer);
            _context.SaveChanges();
        }
    }
}