using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMBD.Models
{
    public class Actor_Movies
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int ActorId { get; set; }
       // public virtual ICollection<Movies> movie { get; set; }
        public virtual Actors Actor { get; set; }
    }
}