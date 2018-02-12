using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMBD.Models;
using System.IO;
using System.Web;

namespace IMBD.Interfaces
{
    interface IProducers
    {
        List<Producers> ListProducers();
        int AddProducer(Producers producer);
        void DeleteProducer(int id);
    }
}
