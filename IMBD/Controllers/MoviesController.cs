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
namespace IMBD.Controllers
{
    public class MoviesController : Controller
    {
        public ActionResult View(int id)
        {
            /*  var movie = new Movies() { Id = 12, Name = "Movies Name" };
              var producer = new Producers() { Name = "Producers Name" };

              var actor = new List<Actors>
              {
                  new Actors { Name="Actor 1"},
                  new Actors { Name="Actor 2" }
              };*/
            ImdbConfiguration conf = new ImdbConfiguration();
            List<Movies> movies = conf.Movies.ToList();

            Movies mv = new Movies();
            
            foreach(Movies m in movies)
            {
                if (id == m.Id)
                {
                    mv = m;
                    break;
                }
            }

         /*   var viewModel = new ViewMovieViewModel
            {
                Vmmovie = movie,
                Vmactors = actor,
                Vmproducer=producer
            };*/

            //  ViewData["Movie"] = movie;
            //   ViewBag.Movie = movie;
            return View(mv);
            //  return View();

           // return View();
        }


        public ActionResult List()
        {

            ImdbConfiguration conf = new ImdbConfiguration();
            List<Movies> movies = conf.Movies.ToList();

            return View(movies);
           
        }

        public ActionResult PopUp()
        {
            return View();
        }

        public ActionResult Add()
        {
            ImdbConfiguration conf = new ImdbConfiguration();
            List<Actor_Movies> dsf = conf.Actor_Movies.ToList();
            List<Actors> actor = conf.Actors.ToList();
            List<Producers> produc = conf.Producers.ToList();

         /*   var viewModel = new AddCustomerViewModel
            {
                Act = actor
            };*/
            AddMovie mov = new AddMovie();
            mov.Actors = actor;
            mov.Prod = produc;
            return View(mov);
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
        public ActionResult Create(AddMovie vm)
        {
            try
            { 
                String s = vm.Name;
                String path = "C:\\users\\rajat\\source\\repos\\IMBD\\IMBD\\Content\\Posters\\";
                //vm.File.SaveAs(path+vm.Id);


                Image source = Image.FromStream(vm.File.InputStream);
                double widthRatio = ((double)100) / source.Width;
                double heightRatio = ((double)100) / source.Height;


                //  DBInit.Init x = new DBInit.Init();
                //  Movies m = new Movies() { Name = vm.Name, ReleaseDate = vm.ReleaseDate, Plot = vm.Plot, ProducerId = vm.ProducerId };
                using (var context = new ImdbConfiguration())
                {
                    var mov = new Movies() {
                        Name = vm.Name,
                        ReleaseDate = vm.ReleaseDate,
                        Plot = vm.Plot,
                        PosterId=123,
                        ProducerId = vm.producer };
                    context.Movies.Add(mov);

                   

                    context.SaveChanges();

                    vm.File.SaveAs(Path.Combine(@path, "" + mov.Id + ".jpg"));

                    foreach (int i in vm.ActorIds)
                    {
                        var actor_mov = new Actor_Movies()
                        {
                            MovieId = mov.Id,
                            ActorId = i
                        };
                        context.Actor_Movies.Add(actor_mov);
                    }
                    context.SaveChanges();
                   
                   
                }

                //cont.Movies.Add(std);
                // TODO: Add insert logic here
               
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

            ImdbConfiguration conf = new ImdbConfiguration();
            List<Movies> movi = conf.Movies.ToList();
            List<Actor_Movies> am = conf.Actor_Movies.ToList();
            List<Actors> actor = conf.Actors.ToList();
            List<Producers> produc = conf.Producers.ToList();

            /*   var viewModel = new AddCustomerViewModel
               {
                   Act = actor
               };*/
            Movies selectedmovie=new Movies();
            foreach(Movies m in movi)
            {
                if (m.Id == id)
                {
                    selectedmovie = m;
                    break;
                }
            }
            Producers selectedproducer = new Producers();
            foreach(Producers p in produc)
            {
                if (p.Id == selectedmovie.ProducerId)
                {
                    selectedproducer = p;
                }
            }
            AddMovie mov = new AddMovie();
            mov.Actors = actor;
            mov.Prod = produc;
            mov.selectedM = selectedmovie;
            mov.selectedP = selectedproducer;
            return View(mov);
           // return View();
        }

        // POST: Movies/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int id)
        {
            
            using (var context = new ImdbConfiguration())
            {
                List<Actor_Movies> am = context.Actor_Movies.ToList();
                var movie = new Movies{ Id = id };
                context.Movies.Attach(movie);
                context.Movies.Remove(movie);
                context.SaveChanges();
                foreach(Actor_Movies movies_actor in am)
                {
                    if (movies_actor.Id == id)
                    {
                        context.Actor_Movies.Attach(movies_actor);
                        context.Actor_Movies.Remove(movies_actor);
                        context.SaveChanges();
                    }
                }
               // var movies_actor = new Actor_Movies { MovieId = id };
            }
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
