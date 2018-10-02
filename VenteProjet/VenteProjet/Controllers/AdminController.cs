using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VenteProjet.Models;

namespace VenteProjet.Controllers
{
    public class AdminController : Controller
    {
        siteventeEntities db = new siteventeEntities();

        public ActionResult GestionClient()
        {
            siteventeEntities db = new siteventeEntities();
            return View(db.Clients);
        }

        [HttpPost]
        public ActionResult GestionClient(string searchClient) 
        {
            siteventeEntities db = new siteventeEntities();
            List<Client> cl;
            if (string.IsNullOrEmpty(searchClient)) {
                cl = db.Clients.ToList(); 
            }
            else{
                cl = db.Clients.Where(x => x.Nom.StartsWith(searchClient)).ToList();
            }
            return View(cl);
        }

        
        //ajax
        public ActionResult getClient(string term)
        {
            ClientM clM = new ClientM();
            return Json(clM.getClient(term),JsonRequestBehavior.AllowGet);
        }

        
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Admin/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Admin/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Create

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
        // GET: /Admin/Editer les client

        public ActionResult Edit(int id=0)
        {
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        //
        // POST: /Admin/Editer les clients

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Index");
                return Redirect(Url.Action("GestionClient", "Admin"));
            }
            return View(client);
        }

        //
        // GET: /Admin/supprimer les clients

        public ActionResult Delete(int id=0)
        {
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        //
        // POST: /Admin/supprimer les clients

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
            db.SaveChanges();
            //return RedirectToAction("Index");
            return Redirect(Url.Action("GestionClient", "Admin"));

        }

        public ActionResult GestionArticle()
        {
            siteventeEntities db = new siteventeEntities();
            return View(db.Articles);
        }

        [HttpPost]
        public ActionResult GestionArticle(string artList)
        {
            siteventeEntities db = new siteventeEntities();
            List<Article> artc;
            if (string.IsNullOrEmpty(artList))
            {
                artc = db.Articles.ToList();
            }
            else
            {
                artc = db.Articles.Where(x => x.Designation.StartsWith(artList)).ToList();
            }
            return View(artc);
        }
       //ajouter article
        [HttpGet]
        public ActionResult CreateArticle() {
            
            return View();
        }

        [HttpPost]
        public ActionResult CreateArticle(Article art)
        {
            string fileName = Path.GetFileNameWithoutExtension(art.ImageFile.FileName);
            string extension = Path.GetExtension(art.ImageFile.FileName);

            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;

            art.photo = "~/Picture/"+fileName;

            fileName = Path.Combine(Server.MapPath("~/Picture/"), fileName);

            art.ImageFile.SaveAs(fileName);

            using(siteventeEntities db= new siteventeEntities()){
                db.Articles.Add(art);
                db.SaveChanges();
            }

            ModelState.Clear();
            return View();
        }

        // GET: /Admin/supprimer les articles

        public ActionResult DeleteArticle(int id = 0)
        {
            Article artl = db.Articles.Find(id);
            if (artl == null)
            {
                return HttpNotFound();
            }
            return View(artl);
        }

        //
        // POST: /Admin/supprimer les articles

        [HttpPost, ActionName("DeleteArticle")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedArticle(int id) 
        {
            Article artl = db.Articles.Find(id);
            db.Articles.Remove(artl);
            db.SaveChanges();
            //return RedirectToAction("Index");
            return Redirect(Url.Action("GestionArticle", "Admin"));

        }

        // GET: /Admin/Editer les articles

        public ActionResult EditArticle(int id = 0)
        {
            Article artl = db.Articles.Find(id);
            if (artl == null)
            {
                return HttpNotFound();
            }
            return View(artl);
        }

        //
        // POST: /Admin/Editer les articles

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditArticle(Article artl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artl).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Index");
                return Redirect(Url.Action("GestionArticle", "Admin"));
            }
            return View(artl);
        }

        // GET: /Admin/supprimer les catégories

        public ActionResult DeleteCateg(int id = 0)
        {
            Categorie cat = db.Categories.Find(id);
            if (cat == null)
            {
                return HttpNotFound();
            }
            return View(cat);
        }

        //
        // POST: /Admin/supprimer les catégories

        [HttpPost, ActionName("DeleteCateg")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedCateg(int id)
        {
            Categorie cat = db.Categories.Find(id);
            db.Categories.Remove(cat);
            db.SaveChanges();
            //return RedirectToAction("Index");
            return Redirect(Url.Action("GestionCateg", "Admin"));

        }

        // GET: /Admin/Editer les Catégories

        public ActionResult EditCateg(int id = 0)
        {
            Categorie cat = db.Categories.Find(id);
            if (cat == null)
            {
                return HttpNotFound();
            }
            return View(cat);
        }

        //
        // POST: /Admin/Editer les Catégories

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCateg(Categorie cat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cat).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Index");
                return Redirect(Url.Action("GestionCateg", "Admin"));
            }
            return View(cat);
        }

        //[HttpPost]
        //public ActionResult GestionArticle(string Designation) 
        //{
            //siteventeEntities db = new siteventeEntities();
            //List<Article> ar;
            //if (string.IsNullOrEmpty(Designation))     
            //{
            //    ar = db.Articles.ToList();
            //}
            //else
            //{
            //    ar = db.Articles.Where(x => x.Designation.StartsWith(Designation)).ToList();
            //}
            //return View(ar);
        //}

        public ActionResult GestionCateg()
        {
            siteventeEntities db = new siteventeEntities();
            return View(db.Categories);
        }

        public ActionResult CreateCateg()
        {
            return View();
        }

        //
        // POST: /Etudiant1/Create

        [HttpPost]
        public ActionResult CreateCateg(Categorie cat)
        {
            try
            {
                // TODO: Add insert logic here
                db.Categories.Add(cat);
                db.SaveChanges();
                return Redirect(Url.Action("GestionCateg", "Admin"));
            }
            catch
            {
                return View();
            }
        }
    }
}
