using Microsoft.AspNetCore.Mvc;
using ReviewsSite.Models;
using ReviewsSite.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsSite.Controllers
{
    public class ReviewController : Controller
    {
        public ReviewRepository reviewRepo;

        public ReviewController(ReviewRepository reviewRepo)
        {
            this.reviewRepo = reviewRepo;
        }
        public ViewResult Index(int? id)
        {
            if(id == null)
            {
                return View(reviewRepo.GetAll());
            } 
            else
            {
                return View(reviewRepo.GetByGameID((int)id));
            }
            
        }

        //CREATE
        public IActionResult Create()
        {
            ViewBag.VideoGames = reviewRepo.PopulateVideoGameList();
            return View(new Review());
        }
        [HttpPost]
        public ActionResult Create(Review review)
        {
            reviewRepo.Create(review);
            return RedirectToAction("Index");
        }

        //UPDATE
        public ViewResult Edit(int id)
        {
            var review = reviewRepo.GetByID(id);
            return View(review);
        }
        [HttpPost]
        public ActionResult Edit(Review review)
        {
            reviewRepo.Update(review);
            return RedirectToAction("Index");

        }

        //DELETE
        public IActionResult Delete(int id)
        {
            Review review = reviewRepo.GetByID(id);
            reviewRepo.Delete(review);
            return RedirectToAction("Index");
        }
    }
}
