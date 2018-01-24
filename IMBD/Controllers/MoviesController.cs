using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IMBD.Models;
using IMBD.ViewModel;
using IMBD.Confuguration;

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

            

         /*   var viewModel = new ViewMovieViewModel
            {
                Vmmovie = movie,
                Vmactors = actor,
                Vmproducer=producer
            };*/

            //  ViewData["Movie"] = movie;
            //   ViewBag.Movie = movie;
            return View(movies);
            //  return View();

           // return View();
        }


        public ActionResult List()
        {

            ImdbConfiguration conf = new ImdbConfiguration();
            List<Movies> movies = conf.Movies.ToList();

            return View(movies);
           
        }



        public ActionResult Add()
        {
            ImdbConfiguration conf = new ImdbConfiguration();
            List<Actors> actor = conf.Actors.ToList();

            var viewModel = new AddCustomerViewModel
            {
                Act = actor
            };
            return View(viewModel);
        }


        public ActionResult Create(AddCustomerViewModel viewModel)
        {
            return View();
        }


        // GET: Movies
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
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
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
            return View();
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
