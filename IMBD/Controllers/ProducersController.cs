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
    public class ProducersController : Controller
    {
        public ActionResult View(int id)
        {
            ImdbConfiguration conf = new ImdbConfiguration();
            List<Producers> Producers = conf.Producers.ToList();

            Producers pr = new Producers();

            foreach (Producers pro in Producers)
            {
                if (id == pro.Id)
                {
                    pr = pro;
                    break;
                }
            }

            return View(pr);


        }


        public JsonResult AddProducer(AddMovie producer)
        {
            try
            {
                using (var context1 = new ImdbConfiguration())
                {
                    var pro = new Producers()
                    {
                        Name = producer.AName,
                        Bio = producer.ABio,
                        Dob = producer.ADob,
                        Sex = producer.ASex,
                    };
                    context1.Producers.Add(pro);
                    context1.SaveChanges();
                    producer.AId = pro.Id;
                }
            }
            catch (Exception e) { string s=e.HelpLink; }
            return Json(producer);
        }

        public ActionResult List()
        {

            ImdbConfiguration conf = new ImdbConfiguration();
            List<Producers> Producers = conf.Producers.ToList();

            return View(Producers);

        }



        public ActionResult Add()
        {
            //ImdbConfiguration conf = new ImdbConfiguration();
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
        public ActionResult Create(Producers vm)
        {
            try
            {

                using (var context = new ImdbConfiguration())
                {
                    var pro = new Producers()
                    {
                        Name = vm.Name,
                        Bio = vm.Bio,
                        Dob = vm.Dob,
                        Sex = vm.Sex,
                    };
                    context.Producers.Add(pro);
                    context.SaveChanges();

                }

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
