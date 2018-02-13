using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMBD.Models;

namespace IMBD.ViewModel
{
    public class AddMovieViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Plot { get; set; }
        public int PosterId { get; set; }
        public string PosterPath { get; set; }
        // public int ProducerId { get; set; }
        //   public ICollection<Actor_Movies> Actor_movie { get; set; }
        public int producer { get; set; }
        public String actor { get; set; }
        public List<int> ActorIds { get; set; }
        public ICollection<Producers> Prod;
     //   public ICollection<Actors> Actors;

        // public int[] actoridarray;
        public List<Actors> Actors;
        public HttpPostedFileBase File { get; set; }
        public string formattedDate;
        public Movies selectedM;
        public Producers selectedP;
        public ICollection<Actors> selectedA;
        public int AId { get; set; }
        public string AName { get; set; }
        public string ASex { get; set; }
        public DateTime ADob { get; set; }
        public string ABio { get; set; }
    }
}