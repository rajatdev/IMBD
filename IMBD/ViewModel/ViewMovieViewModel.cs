using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMBD.Models;

namespace IMBD.ViewModel
{
    public class ViewMovieViewModel
    {
        public Movies Vmmovie { get; set; }
        public Producers Vmproducer { get; set; }
        public List<Actors> Vmactors { get; set; }
    }
}