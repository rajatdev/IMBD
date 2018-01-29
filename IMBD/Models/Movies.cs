using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMBD.Models
{
    public class Movies
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Plot { get; set; }
        public int PosterId { get; set; }
        public int ProducerId { get; set; }
        public virtual ICollection<Actor_Movies> Actor_movie { get; set; }
        public virtual Producers producer { get; set; }
       // public ICollection<Actors> Actors;
    }
}