using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WheresMyMUA.Models;
using WheresMyMUA.ViewModels;



namespace WheresMyMUA.Controllers
{
    public class ArtistsController : Controller
    {
        public IActionResult Index()
        {
           
            ArtistsRepository repo = new ArtistsRepository();

            ArtistsViewModels viewModel = new ArtistsViewModels();

            viewModel.Artists = repo.GetAllArtists();//now we give artists a value

            return View(viewModel);
            //test
        }

        public IActionResult NewArtist()
        {
            return View();
        }

        public IActionResult Add(string name, string specialty, string location, int phone)
        {
            ArtistsRepository repo = new ArtistsRepository();
            repo.InsertArtist(name, specialty, location, phone);

            return RedirectToAction("Index"); //misspelled Artists
        }
    }
}

