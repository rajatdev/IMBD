using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IMBD.Models;
using IMBD.ViewModel;
using IMBD.Confuguration;
using System.IO;
using System.Drawing;
using IMBD.Repository;
using System.Configuration;

namespace IMBD.Controllers
{
    public class MoviesController : Controller
    {

        MoviesRepository moviesRepository;
        ProducersRepository producersRepository;
        ActorsRepository actorsRepository;
        Actor_MoviesRepository actor_MoviesRepository;

        public MoviesController()
        {
            moviesRepository = new MoviesRepository();

            producersRepository = new ProducersRepository();

            actorsRepository = new ActorsRepository();

            actor_MoviesRepository = new Actor_MoviesRepository();


        }
        public ActionResult View(int id)
        {

            List<Movies> movies = moviesRepository.ListMovie();

            Movies movie = movies.Where(s => s.Id == id).Single();



            return View(movie);

        }


        public ActionResult List()
        {


            List<Movies> movies = moviesRepository.ListMovie();

            return View(movies);

        }

        public ActionResult PopUp()
        {
            return View();
        }

        public ActionResult Add()
        {
            List<Actors> actor = actorsRepository.ListActors();
            List<Producers> producers = producersRepository.ListProducers();


            var viewModel = new AddMovieViewModel
            {
                Actors = actor,
                Prod = producers
            };

            return View(viewModel);
        }


        public ActionResult create(AddCustomerViewModel viewModel)
        {

            return View();
        }


        // GET: Movies
        [HttpPost]
        public ActionResult Index()
        {

            return View();
        }

        // GET: Movies/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        public ActionResult Create(AddMovieViewModel viewmodel)
        {
            try
            {
                String s = viewmodel.Name;
                String path = "C:\\users\\rajat\\source\\repos\\IMBD\\IMBD\\Content\\Posters\\";
                //String path = ConfigurationManager.AppSettings["Path"];
                //   viewmodel.File.SaveAs(path+viewmodel.Id);


                Image source = Image.FromStream(viewmodel.File.InputStream);

                var NewMovie = new Movies()
                {
                    Name = viewmodel.Name,
                    ReleaseDate = viewmodel.ReleaseDate,
                    Plot = viewmodel.Plot,
                    PosterId = 123,
                    ProducerId = viewmodel.producer
                };
                moviesRepository.AddMovie(NewMovie);


                viewmodel.File.SaveAs(Path.Combine(@path, "" + NewMovie.Id + ".jpg"));

                foreach (int i in viewmodel.ActorIds)
                {
                    var actor_mov = new Actor_Movies()
                    {
                        MovieId = NewMovie.Id,
                        ActorId = i
                    };
                    actor_MoviesRepository.Add(actor_mov);

                }

                return RedirectToAction("Add");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movies/Edit/5
        public ActionResult Modify(int id)
        {

            List<Movies> movies = moviesRepository.ListMovie();
            Movies selectedmovie = (from m in movies
                                    where m.Id == id
                                    select m).Single();
            List<Producers> producers = producersRepository.ListProducers();
            Producers selectedproducer = (from p in producers
                                          where p.Id == selectedmovie.ProducerId
                                          select p).Single();

            List<Actors> actors = actorsRepository.ListActors();
            List<Actor_Movies> actor_movies = actor_MoviesRepository.ListActor_Movies();

            List<Actors> selectedActors = new List<Actors>();


            AddMovieViewModel viewmodel = new AddMovieViewModel();


            foreach (Actor_Movies actor_movie in selectedmovie.Actor_movie)
            {
                if (actor_movie.MovieId == selectedmovie.Id)
                {
                    Actors act = (from s in actors
                                  where s.Id == actor_movie.ActorId
                                  select s).Single();
                    selectedActors.Add(act);
                }
            }


            string temp = selectedmovie.ReleaseDate.ToString("yyyy-MM-dd");
            viewmodel.ReleaseDate = Convert.ToDateTime(temp);
            viewmodel.Actors = actors;
            viewmodel.Prod = producers;
            viewmodel.Plot = selectedmovie.Plot;
            viewmodel.selectedM = selectedmovie;
            viewmodel.selectedP = selectedproducer;
            viewmodel.selectedA = selectedActors;
            return View(viewmodel);

        }

        // POST: Movies/Edit/5
        [HttpPost]
        public ActionResult Edit(AddMovieViewModel viewmodel)
        {
            try
            {
                String s = viewmodel.Name;


                var movie = new Movies()
                {
                    Name = viewmodel.Name,
                    ReleaseDate = viewmodel.ReleaseDate,
                    Plot = viewmodel.Plot,
                    PosterId = 123,
                    ProducerId = viewmodel.producer
                };
                moviesRepository.ModifyMovie(movie, viewmodel.ActorIds, viewmodel.File);




                return RedirectToAction("List");

            }
            catch
            {
                return RedirectToAction("List");
            }
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int id)
        {
            List<Movies> movies = moviesRepository.ListMovie();

            Movies movie = (from m in movies
                            where m.Id == id
                            select m).Single();


            moviesRepository.DeleteMovie(movie);

            return RedirectToAction("List");
        }

        // POST: Movies/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
