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
    public class ProducersController : Controller
    {

       
        ProducersRepository producersRepository;
       

        public ProducersController()
        {
          

            producersRepository = new ProducersRepository();


        }
        public ActionResult View(int id)
        {
            
            List<Producers> Producers = producersRepository.ListProducers();

            Producers producer = Producers.Where(p => p.Id == id).Single();

            

            return View(producer);


        }

        [HttpPost]
        public JsonResult AddProducer(AddMovieViewModel producer)
        {
            try
            {
                
                    var newProducer = new Producers()
                    {
                        Name = producer.AName,
                        Bio = producer.ABio,
                        Dob = producer.ADob,
                        Sex = producer.ASex,
                    };
                    
                    producer.AId = producersRepository.AddProducer(newProducer);
               
            }
            catch (Exception e) { string s=e.HelpLink; }
            return Json(producer);
        }

        public ActionResult List()
        {

            
            List<Producers> Producers = producersRepository.ListProducers();

            return View(Producers);

        }



        public ActionResult Add()
        {
            
            Producers producer = new Producers();

            return View(producer);
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
        public ActionResult Create(Producers viewmodel)
        {
            try
            {

                
                    var producer = new Producers()
                    {
                        Name = viewmodel.Name,
                        Bio = viewmodel.Bio,
                        Dob = viewmodel.Dob,
                        Sex = viewmodel.Sex,
                    };
                producersRepository.AddProducer(producer);

                

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
            producersRepository.DeleteProducer(id);
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
