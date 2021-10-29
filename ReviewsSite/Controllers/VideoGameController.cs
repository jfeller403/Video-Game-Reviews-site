using Microsoft.AspNetCore.Mvc;
using ReviewsSite.Models;
using ReviewsSite.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsSite.Controllers
{
    public class VideoGameController : Controller
    {
        public VideoGameRepository videoGameRepo;
        public VideoGameController(VideoGameRepository videoGameRepo)
        {
            this.videoGameRepo = videoGameRepo;
        }
        public ViewResult Index()
        {
            return View(videoGameRepo.GetAll());
        }
        public ViewResult Details(int id)
        {
            return View(videoGameRepo.GetByID(id));
        }

        //CREATE
        public IActionResult Create()
        {
            return View(new VideoGame());
        }
        [HttpPost]
        public ActionResult Create(VideoGame videogame)
        {
            videoGameRepo.Create(videogame);
            return RedirectToAction("Index");
        }

        //EDIT
        public ViewResult Edit(int id)
        {
            var review = videoGameRepo.GetByID(id);
            return View(review);
        }
        [HttpPost]
        public ActionResult Edit(VideoGame videogame)
        {
            videoGameRepo.Update(videogame);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            VideoGame videogame = videoGameRepo.GetByID(id);
            videoGameRepo.Delete(videogame);
            return RedirectToAction("Index");
        }
    }
}
