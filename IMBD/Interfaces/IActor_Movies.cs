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
    interface IActor_Movies
    {
       List<Actor_Movies> ListActor_Movies();
        void Add(Actor_Movies actor_movie);
    }
}
