using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IMBD.Models;
using IMBD.ViewModel;
using IMBD.Repository;
using IMBD.Confuguration;

namespace IMBD.Controllers
{
    public class ActorsController : Controller
    {
        ActorsRepository _actorsRepository;


        public ActorsController()
        {


            _actorsRepository = new ActorsRepository();


        }
        public ActionResult View(int id)
        {
            //ImdbConfiguration conf = new ImdbConfiguration();
            List<Actors> actors = _actorsRepository.ListActors();

            Actors actor = actors.Where(a => a.Id == id).Single();

            

            return View(actor);
           

        }


        public ActionResult List()
        {


            List<Actors> actors = _actorsRepository.ListActors();

            return View(actors);

        }

        [HttpPost]
        public JsonResult AddActor(AddMovieViewModel actor)
        {
            try { 
            
                var newActor = new Actors()
                {
                    Name = actor.ModalName,
                    Bio = actor.ModalBio,
                    Dob = actor.ModalDob,
                    Sex = actor.ModalSex,
                };
                
                actor.ModalId = _actorsRepository.AddActor(newActor);
            
            }
            catch (Exception e) { string s = e.HelpLink; }
            return Json(actor);
        }

        public ActionResult Add()
        {
            //ImdbConfiguration conf = new ImdbConfiguration();
            Actors actor = new Actors();
            
            return View(actor);
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
        public ActionResult Create(Actors viewmodel)
        {
            try { 
                    var newActor = new Actors()
                    {
                        Name = viewmodel.Name,
                        Bio = viewmodel.Bio,
                        Dob = viewmodel.Dob,
                        Sex = viewmodel.Sex,
                    };
            _actorsRepository.AddActor(newActor);

               
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


            // var actor = new Actors { Id = id };

            _actorsRepository.DeleteActor(id);
           
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
