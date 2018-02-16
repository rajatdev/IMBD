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
using IMBD.Helper;
using RestSharp;
using Newtonsoft.Json.Linq;
using System.Net;

namespace IMBD.Controllers
{
    public class MoviesController : Controller
    {

        MoviesRepository _moviesRepository;
        ProducersRepository _producersRepository;
        ActorsRepository _actorsRepository;
        Actor_MoviesRepository _actor_MoviesRepository;

        public MoviesController()
        {
            _moviesRepository = new MoviesRepository();

            _producersRepository = new ProducersRepository();

            _actorsRepository = new ActorsRepository();

            _actor_MoviesRepository = new Actor_MoviesRepository();


        }
        public ActionResult View(int id)
        {

            List<Movies> movies = _moviesRepository.ListMovie();

            Movies movie = movies.Where(s => s.Id == id).Single();



            return View(movie);

        }


        public ActionResult List()
        {


            List<Movies> movies = _moviesRepository.ListMovie();


            using(var c = new ImdbConfiguration())
            {
                var x = c.Actor_Movies.Include("Actor").ToList();
            }


                return View(movies);

        }




        public ActionResult ListImdb()
        {
           
            

          //  int i = 1;
            return View();
        }

        public ActionResult addFromApi(String movieName)
        {
            String url = Helper.Helper.GetMoviesApiPath() + movieName + "&" + Helper.Helper.GetMoviesApiKey();
            var client = new RestClient(url);
            IRestResponse response = client.Execute(new RestRequest());
            List<Actors> actors = _actorsRepository.ListActors();
            dynamic newMovie = JObject.Parse(response.Content);
            if (newMovie!=null)
            {
                Movies movie = new Movies();
                //   movie.Name = (String)newMovie.Value("Title");
                if (newMovie.Title != null)
                    movie.Name = newMovie.Title;
                else
                    return RedirectToAction("List");
                if (newMovie.Plot != null || newMovie.Plot != "{N/A}")
                    movie.Plot = newMovie.Plot;
                else
                    return RedirectToAction("List");
                if (newMovie.Released != null || newMovie.Released != "{N/A}")
                    movie.ReleaseDate = newMovie.Released;

                //  Producers producer = new Producers { Id = 201 };
                //movie.producer = producer;
                movie.ProducerId = 201;
                HttpPostedFileBase File = null;
                int MovieId=0;
                movie.PosterId = newMovie.Poster;
                string actorData = newMovie.Actors;
                string[] values = actorData.Split(',');
                MovieId=_moviesRepository.AddMovie(movie, File);
                foreach (var data in values)
                {
                    Actors actor = new Actors();
                    int id=0;
                    actor.Name = data;
                    if (actors.Where(a => a.Name == data).Count() == 0)
                        id = _actorsRepository.AddActor(actor);
                    else
                        id = actors.Where(a => a.Name == data).Single().Id;
                    Actor_Movies actor_movie = new Actor_Movies();
                    actor_movie.ActorId = id;
                    actor_movie.MovieId = MovieId;
                    _actor_MoviesRepository.Add(actor_movie);

                }
                //byte[] bytes;
                //HttpWebRequest req = (HttpWebRequest)WebRequest.Create(newMovie.Poster);
                //WebResponse resp = req.GetResponse();

                //Stream stream = resp.GetResponseStream();
                //using (BinaryReader br = new BinaryReader(stream))
                //{
                //    bytes = br.ReadBytes(500000);
                //    br.Close();
                //}
                //resp.Close();



               
            }
            else
            {

            }




            return RedirectToAction("List");
        }



        public ActionResult Add()
        {
            List<Actors> actor = _actorsRepository.ListActors();
            List<Producers> producers = _producersRepository.ListProducers();


            var viewModel = new AddMovieViewModel
            {
                Actors = actor,
                Producers = producers
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
        public ActionResult Create(AddMovieViewModel viewModel)
        {
            try
            {
                //String s = viewmodel.Name;
                //String ss = Environment.CurrentDirectory;
                // String path = "C:\\users\\rajat\\source\\repos\\IMBD\\IMBD\\Content\\Posters\\";
                // String path2 = HttpContext("~/Data/data.html");
            //    String path = Helper.Helper.GetPosterPath();
                //   viewmodel.File.SaveAs(path+viewmodel.Id);
               
              //  path1 = ss + path1;
               // Image source = Image.FromStream(viewmodel.File.InputStream);

                var NewMovie = new Movies()
                {
                    Name = viewModel.Name,
                    ReleaseDate = viewModel.ReleaseDate,
                    Plot = viewModel.Plot,
                    PosterId = "123",
                    ProducerId = viewModel.ProducerId
                };
                _moviesRepository.AddMovie(NewMovie,viewModel.File);


              //  viewModel.File.SaveAs(Path.Combine(Server.MapPath(path)+"" + NewMovie.Id + ".jpg"));





                foreach (int i in viewModel.ActorIds)
                {
                    var actor_mov = new Actor_Movies()
                    {
                        MovieId = NewMovie.Id,
                        ActorId = i
                    };
                    _actor_MoviesRepository.Add(actor_mov);

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

            List<Movies> movies = _moviesRepository.ListMovie();
            Movies selectedmovie = movies.Where(m => m.Id == id).Single();
            List<Producers> producers = _producersRepository.ListProducers();
            Producers selectedproducer = producers.Where(p => p.Id == selectedmovie.ProducerId).Single();

            List<Actors> actors = _actorsRepository.ListActors();
            List<Actor_Movies> actor_movies = _actor_MoviesRepository.ListActor_Movies();

            List<Actors> selectedActors = new List<Actors>();


            AddMovieViewModel viewmodel = new AddMovieViewModel();


            foreach (Actor_Movies actor_movie in selectedmovie.Actor_movie)
            {
                if (actor_movie.MovieId == selectedmovie.Id)
                {
                    Actors actor = actors.Where(a => a.Id == actor_movie.ActorId).Single();
                    selectedActors.Add(actor);
                }
            }


            viewmodel.FormattedDate = selectedmovie.ReleaseDate.ToString("yyyy-MM-dd");
           // viewmodel.ReleaseDate = Convert.ToDateTime(temp);
            viewmodel.Actors = actors;
            viewmodel.Producers = producers;
            viewmodel.Plot = selectedmovie.Plot;
            viewmodel.SelectedMovie = selectedmovie;
            viewmodel.SelectedProducer = selectedproducer;
            viewmodel.SelectedActors = selectedActors;
            return View(viewmodel);

        }

        // POST: Movies/Edit/5
        [HttpPost]
        public ActionResult Edit(AddMovieViewModel viewModel)
        {
            try
            {
                String s = viewModel.Name;


                var movie = new Movies()
                {
                    Name = viewModel.Name,
                    ReleaseDate = viewModel.ReleaseDate,
                    Plot = viewModel.Plot,
                    PosterId = "123",
                    ProducerId = viewModel.ProducerId
                };
                _moviesRepository.ModifyMovie(movie, viewModel.ActorIds, viewModel.File);




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
            List<Movies> movies = _moviesRepository.ListMovie();

            Movies movie = movies.Where(m => m.Id == id).Single();


            _moviesRepository.DeleteMovie(movie);

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
