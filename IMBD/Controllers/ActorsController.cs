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
    public class ActorsController : Controller
    {
        public ActionResult View(int id)
        {
            ImdbConfiguration conf = new ImdbConfiguration();
            List<Actors> actors = conf.Actors.ToList();

            Actors ac = new Actors();

            foreach (Actors a in actors)
            {
                if (id == a.Id)
                {
                    ac = a;
                    break;
                }
            }

            return View(ac);
           

        }


        public ActionResult List()
        {

            ImdbConfiguration conf = new ImdbConfiguration();
            List<Actors> actors = conf.Actors.ToList();

            return View(actors);

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
        public ActionResult Create(Actors vm)
        {
            try
            {
                
                using (var context = new ImdbConfiguration())
                {
                    var act = new Actors()
                    {
                        Name = vm.Name,
                        Bio = vm.Bio,
                        Dob = vm.Dob,
                        Sex = vm.Sex,
                    };
                    context.Actors.Add(act);
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
