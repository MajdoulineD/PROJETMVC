using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VenteProjet.Models;

namespace VenteProjet.Controllers
{
    public class ClientController : Controller
    {
        //
        // GET: /Gestion catalogues/

        siteventeEntities db = new siteventeEntities();

        public ActionResult GestionCatalog()
        {
            siteventeEntities db = new siteventeEntities();
            return View(db.Articles);
        }

        public ActionResult GestionCommande()
        {
            siteventeEntities db = new siteventeEntities();
            return View(db.Articles);
        }

        //ajouter commande
        public ActionResult ajoutProduit()
        {
            return View();
        }

        //
        // POST: /Etudiant1/Create

        [HttpPost]
        public ActionResult ajoutProduit(Article art)
        {
            try
            {
                // TODO: Add insert logic here
                db.Articles.Add(art);
                db.SaveChanges();
                return Redirect(Url.Action("ajoutProduit", "Client"));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult LancerCommande() {
            return View();
        }
        [HttpPost]
        public ActionResult LancerCommande(Commande comm)
        {
            try
            {
                // TODO: Add insert logic here
                db.Commandes.Add(comm);
                db.SaveChanges();
                return Redirect(Url.Action("LancerCommande", "Client"));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Client/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //details catalogues
        public ActionResult DetailsCatalogue(int id)
        {
            Article article = db.Articles.Find(id);
            if (article == null)
            { 
                return HttpNotFound();
            }
            return View(article);
        }
        //
        // GET: /Client/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Client/Create

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
        // GET: /Client/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Client/Edit/5

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
        // GET: /Client/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Client/Delete/5

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
