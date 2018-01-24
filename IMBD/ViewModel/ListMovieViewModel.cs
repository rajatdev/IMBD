using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMBD.Models;

namespace IMBD.ViewModel
{
    public class ListMovieViewModel
    {
        // GET: ListMovieViewModel
        public List<Movies> Vmmovies { get; set; }
        public List<Actors> Vmactors { get; set; }
        public List<Producers>  Vmproducer { get; set; }
        public List<Actor_Movies> Vmactor_movies { get; set; }


    }
}