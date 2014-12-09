using S00127670_CA2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Net;
using System.Diagnostics;

namespace S00127670_CA2.Controllers
{
    public class HomeController : Controller
    {
        MovieDb db = new MovieDb();

        //
        // GET: /Home/

        public ActionResult Index(string sortActor)
        {
            ViewBag.PageTitle = "Movie List (" + db.movie.Count() + ")";
            if (sortActor == null) sortActor = "NumberUp";
            ViewBag.numOrder = (sortActor == "NumberUp") ? "NumberDown" : "NumberUp";

            IQueryable<Movie> movies = db.movie;
            switch (sortActor)
            {
                case "NumberDown":
                    ViewBag.numOrder = "NumberUp";
                    movies = movies.OrderByDescending(a => a.actors.Count);
                    break;
                case "NumberUp":
                    ViewBag.numOrder = "NumberDown";
                    movies = movies.OrderBy(a => a.actors.Count);
                    break;
                default:
                    ViewBag.numOrder = "NumberUp";
                    movies = movies.OrderBy(a => a.actors.Count);
                    break;
            }
            ViewBag.Action = db.movie.Count(mg => mg.movieGenre == MovieGenre.Action);
            ViewBag.Adventure = db.movie.Count(mg => mg.movieGenre == MovieGenre.Adventure);
            ViewBag.Animation = db.movie.Count(mg => mg.movieGenre == MovieGenre.Animation);
            ViewBag.Comedy = db.movie.Count(mg => mg.movieGenre == MovieGenre.Comedy);
            ViewBag.Horror = db.movie.Count(mg => mg.movieGenre == MovieGenre.Horror);
            return View(movies.ToList());
        }

        //
        // GET: /Home/Details/5

        public ActionResult DetailsActor(int id)
        {
            ViewBag.DA = "Movies" + " " + db.actor.Find(id).actorName + " " + "Has Starred In" + " " + "(" + db.movie.Count() + ")";
            return View();
        }

        //
        // GET: /Home/Create

        public PartialViewResult ActorsById(int id)
        {
            ViewBag.ActorTitle = "Actor List For" + " " + db.movie.Find(id).movieTitle + " " + "(" + db.movie.Find(id).actors.Count() + ")";
            ViewBag.AI = "List Of Actors In " + " " + db.movie.Find(id).movieTitle;
            return PartialView("_ActorsInMovie", db.movie.Find(id).actors);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult CreateActor()
        {
            return View();
        }

        //
        // POST: /Home/Create

        [HttpPost]
        public ActionResult Create(Movie incomingMovie)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var db2 = new MovieDb())
                    {
                        db2.movie.Add(incomingMovie);
                        db2.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult CreateActor(Actor incomingActor)
        {
                if (ModelState.IsValid)
                {
                    db.actor.Add(incomingActor);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return null;
        }

        //
        // GET: /Home/Edit/5

        public PartialViewResult EditMovie(int id)
        {
            ViewBag.EM = "Edit Movie" + " " + "(" + db.movie.Find(id).movieTitle + ")";
            return PartialView("_EditMovie", db.movie.Find(id));
        }

        public ActionResult EditActor(int id)
        {
            ViewBag.EA = "Edit Actor" + " " + "(" + db.actor.Find(id).actorName + ")";
            return View(db.actor.Find(id));
        }

        //
        // POST: /Home/Edit/5

        

        [HttpPost, ActionName("EditMovie")]
        public ActionResult Edit(Movie editMovie)
        {
            try
            {
                db.Entry(editMovie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult EditActor(Actor editActor)
        {
            try
            {
                db.Entry(editActor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Delete/5

        public PartialViewResult DeleteMovie(int id)
        {
            ViewBag.DM = "Delete Movie" + " " + "(" + db.movie.Find(id).movieTitle + ")";
            return PartialView("_DeleteMovie", db.movie.Find(id));
        }

        public ActionResult DeleteActor(int id)
        {
            ViewBag.DA = "Delete Actor" + " " + "(" + db.actor.Find(id).actorName + ")";
            return View(db.actor.Find(id));
        }

        //
        // POST: /Home/Delete/5

        [HttpPost, ActionName("DeleteMovie")]
        public ActionResult DeleteConfirmed(int id)
        {
            db.movie.Remove(db.movie.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");           
        }

        [HttpPost, ActionName("DeleteActor")]
        public ActionResult DeleteConfirmedTwo(int id)
        {
            db.actor.Remove(db.actor.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }  
    }
}
