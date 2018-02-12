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
        public static ImdbConfiguration context;
        public ProducersRepository()
        {
            context = new ImdbConfiguration();
        }

        public List<Producers> ListProducers()
        {
            return context.Producers.ToList();
        }
    }
}