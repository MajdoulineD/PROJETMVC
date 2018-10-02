using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VenteProjet.Models;

namespace VenteProjet.Controllers
{
    public class LoginRegisterController : Controller
    {
        siteventeEntities db = new siteventeEntities();
        //
        // GET: /LoginRegister/

        public ActionResult Inscription()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Inscription(Client cl)
        {
            try
            {
                db.Clients.Add(cl);
                db.SaveChanges();
                //return RedirectToAction("Index");
                Session["Nom"] = cl.Nom;
                Session["Prenom"] = cl.Prenom;
                return Redirect(Url.Action("Index", "Client"));
            }
            catch
            {
                return View();
            }

        }

        public ActionResult Identification()
        {
            return View();
        }

        //
        // POST: /test/Create

        [HttpPost]
        public ActionResult Identification(Client cl) 
        {
            if (ModelState.IsValid)
            {
                var infos = (from clientListe in db.Clients
                             where clientListe.login == cl.login && clientListe.MotPasse == cl.MotPasse
                             select new
                             {
                                 clientListe.Nom,
                                 clientListe.Prenom
                             }).ToList();
                if (infos.FirstOrDefault() != null)
                {
                    Session["Nom"] = infos.FirstOrDefault().Nom;
                    Session["Prenom"] = infos.FirstOrDefault().Prenom;

                    return RedirectToAction("Index", "Client");
                }
            }
            if (ModelState.IsValid)
            {
                if (cl.login.Equals("admin") && cl.MotPasse.Equals("12345"))
                {

                    return RedirectToAction("Index", "Admin");
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid");
            }
            return View(cl);
        }

        public ActionResult Deconnexion()
        {
            Session["Nom"] = null;
            Session["Prenom"] = null;
            return Redirect(Url.Action("Index", "Home"));
        }

        //[HttpPost]
        //public ActionResult Deconnexion(Client cl)
        //{
        //    try
        //    {
        //        Session["Nom"] = null;
        //        Session["Prenom"] = null;
        //        return Redirect(Url.Action("Index", "Home"));
        //    }
        //    catch
        //    {
        //        return View();
        //    }

        //}
        
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /LoginRegister/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /LoginRegister/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /LoginRegister/Create

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

        //
        // GET: /LoginRegister/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /LoginRegister/Edit/5

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

        //
        // GET: /LoginRegister/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /LoginRegister/Delete/5

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
