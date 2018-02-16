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
        public string PosterId { get; set; }
     //   public string PosterPath { get; set; }
        // public int ProducerId { get; set; }
        //   public ICollection<Actor_Movies> Actor_movie { get; set; }
        public int ProducerId { get; set; }
     //   public String actor { get; set; }
        public List<int> ActorIds { get; set; }
        public ICollection<Producers> Producers;
     //   public ICollection<Actors> Actors;

        // public int[] actoridarray;
        public List<Actors> Actors;
        public HttpPostedFileBase File { get; set; }
        public string FormattedDate;
        public Movies SelectedMovie;
        public Producers SelectedProducer;
        public ICollection<Actors> SelectedActors;
        public int ModalId { get; set; }
        public string ModalName { get; set; }
        public string ModalSex { get; set; }
        public DateTime ModalDob { get; set; }
        public string ModalBio { get; set; }
    }
}