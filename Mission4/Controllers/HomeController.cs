using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission4.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4.Controllers
{
    public class HomeController : Controller
    {

        private MovieContext cmContext { get; set; }

        public HomeController(MovieContext someName)
        {
            cmContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcast()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NewMovie()
        {
            ViewBag.Categories = cmContext.Categories.ToList();
            
            return View();
        }

        [HttpPost]
        public IActionResult NewMovie(CreateMovie cm)
        {
            if (ModelState.IsValid)
            {
                cmContext.Add(cm);
                cmContext.SaveChanges();
                return View("Confirmation", cm);
            }

            else
            {
                return View(cm);
            }
            
        }

        [HttpGet]
        public IActionResult MovieTable()
        {
            var movies = cmContext.responses
                .Include(x => x.Category)
                .ToList();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit (int movieid)
        {
            ViewBag.Categories = cmContext.Categories.ToList();

            var movie = cmContext.responses.Single (x => x.ApplicationId == movieid);

            return View("NewMovie", movie);
        }

        [HttpPost]
        public IActionResult Edit(CreateMovie cm)
        {
            if (ModelState.IsValid)
            {
                cmContext.Update(cm);
                cmContext.SaveChanges();
                return RedirectToAction("MovieTable");
            }

            else
            {
                return View("NewMovie");
            }
            
        }

        [HttpGet]
        public IActionResult Delete (int movieid)
        {
            var movie = cmContext.responses.Single(x => x.ApplicationId == movieid);

            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete (CreateMovie cm)
        {
            cmContext.responses.Remove(cm);
            cmContext.SaveChanges();

            return RedirectToAction("MovieTable");
        }
    }
}
