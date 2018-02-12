using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMBD.Models;
using IMBD.Interfaces;
using IMBD.Confuguration;
using System.Drawing;
using System.Configuration;
using System.IO;
namespace IMBD.Repository 
{
    public class MoviesRepository : IMovies
    {
        
        static ImdbConfiguration _context;
        public MoviesRepository()
        {
            _context = new ImdbConfiguration();
        }
        
        public List<Movies> ListMovie()
        {
            return _context.Movies.ToList();
        }

        public void AddMovie(Movies movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        public void ModifyMovie(Movies movie,List<int> actorids,HttpPostedFileBase File)
        {
            // String path = ConfigurationManager.AppSettings["Path"];
            String path = "C:\\users\\rajat\\source\\repos\\IMBD\\IMBD\\Content\\Posters\\";
            Movies modify = _context.Movies.First(m => m.Name == movie.Name);
            List<Actor_Movies> actorMovies = _context.Actor_Movies.ToList();
            modify.Name = movie.Name;
            modify.Plot = movie.Plot;
            modify.ReleaseDate = movie.ReleaseDate;
            modify.ProducerId = movie.ProducerId;
            _context.SaveChanges();

            File.SaveAs(Path.Combine(@path, "" + modify.Id + ".jpg"));
            bool present = false;

            List<int> existingIds= new List<int>();
            existingIds = actorMovies.Where(s => s.MovieId == modify.Id).Select(s => s.ActorId).ToList();
            //existingIds = (from am in actormovies where am.MovieId == modify.Id select am.ActorId).ToList();
            foreach (int id in actorids)
            {
               
                if((actorMovies.Where(s=>s.ActorId == id && s.MovieId==modify.Id).Count()==0))
                {
                    var actor_movie = new Actor_Movies()
                    {
                        MovieId = modify.Id,
                        ActorId = id
                    };
                    _context.Actor_Movies.Add(actor_movie);
                    _context.SaveChanges();
                }

            }
            foreach(int eid in existingIds)
            {
                present = false;
                foreach(int id in actorids)
                {
                    if (eid == id)
                    {
                        present = true;
                        break;
                    }
                }
                if (!present)
                {
                    Actor_Movies actor_Movie = actorMovies.Where(a => a.MovieId == modify.Id && a.ActorId==eid).Single();
                   // Actor_Movies actor_movie = (from am in actormovies where am.MovieId == modify.Id where am.ActorId == eid select am).First();
                 
                    _context.Actor_Movies.Remove(actor_Movie);
                    _context.SaveChanges();
                }
            }
        
            

        }

        public void DeleteMovie(Movies movie)
        {
            List<Actor_Movies> actorMovies = _context.Actor_Movies.ToList();
           
            _context.Movies.Attach(movie);
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            actorMovies = actorMovies.Where(e=> e.MovieId == movie.Id).ToList();
            //actormovies=(from am in actormovies where am.MovieId == movie.Id select am).ToList();
            foreach (Actor_Movies movie_actor in actorMovies)
            {              
                    _context.Actor_Movies.Attach(movie_actor);
                    _context.Actor_Movies.Remove(movie_actor);
                    _context.SaveChanges();
        
            }
        }
    }
}