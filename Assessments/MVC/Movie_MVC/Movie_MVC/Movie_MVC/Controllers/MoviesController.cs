using Movie_MVC.Models;
using Movie_MVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movie_MVC.Controllers
{
    public class MoviesController : Controller
    {
        IMovieRepository repo = new MovieRepository();

        public ActionResult Index()
        {
            return View(repo.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            repo.Insert(movie);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View(repo.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            repo.Update(movie);
            return RedirectToAction("Index");
        }

        [HttpGet]

        public ActionResult Delete(int id)
        {
            var movie = repo.GetById(id);
            return View(movie);
        }

        [HttpPost]
        public ActionResult Delete(Movie movie)
        {
            repo.Delete(movie.Mid);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ByYear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MoviesByYear(int year)
        {
            return View(repo.GetByYear(year));
        }

        [HttpGet]
        public ActionResult ByDirector()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MoviesByDirector(string director)
        {
            return View(repo.GetByDirector(director));
        }
    }
}