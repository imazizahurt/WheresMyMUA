using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WheresMyMUA.Models;


namespace WheresMyMUA.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {             return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Artists()
        {
            ViewData["Message"] = "Your application description page.";

            ArtistsRepository repo = new ArtistsRepository();

            List<Artist> artists = repo.GetAllArtists();

            return View(artists);
        }

        public IActionResult ArtistSignUp()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Do you have an idea of how we can improve functionality?\nOr perhaps you are a savvy entrepreneur interested in investing?\n";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
