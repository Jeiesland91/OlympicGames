using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OlympicGames.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OlympicGames.Controllers
{
    public class HomeController : Controller
    {
        private CountryContext context;

        public HomeController(CountryContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index(string activeGame = "all", string activeSport = "all", string activeCategory = "all")
        {
            var session = new CountrySession(HttpContext.Session);
            session.SetActiveGame(activeGame);
            session.SetActiveSport(activeSport);
            session.SetActiveCategory(activeCategory);

            // if no count value in session, use data in cookie to restore fave Countries in session 
            int? count = session.GetMyCountryCount();
            if (count == null)
            {
                var cookies = new CountryCookies(HttpContext.Request.Cookies);
                string[] ids = cookies.GetMyCountryIds();

                List<Country> myCountries = new List<Country>();
                if (ids.Length > 0)
                    myCountries = context.Countries.Include(c => c.Game)
                        .Include(c => c.Sport)
                        .Include(c => c.Category)
                        .Where(c => ids.Contains(c.CountryId)).ToList();
                session.SetMyCountries(myCountries);
            }

            var model = new CountryListViewModel
            {
                ActiveGame = activeGame,
                ActiveSport = activeSport,
                ActiveCategory = activeCategory,
                Games = context.Games.ToList(),
                Sports = context.Sports.ToList(),
                Categories = context.Categories.ToList()
            };

            IQueryable<Country> query = context.Countries;
            if (activeGame != "all")
                query = query.Where(
                    c => c.Game.GameId.ToLower() == activeGame.ToLower());
            if (activeSport != "all")
                query = query.Where(
                    c => c.Sport.SportId.ToLower() == activeSport.ToLower());
            if (activeCategory != "all")
                query = query.Where(
                    c => c.Category.CategoryId.ToLower() == activeCategory.ToLower());
            model.Countries = query.ToList();

            return View(model);
        }

        public IActionResult Details(string id)
        {
            var session = new CountrySession(HttpContext.Session);
            var model = new CountryViewModel
            {
                Country = context.Countries
                    .Include(c => c.Game)
                    .Include(c => c.Sport)
                    .Include(c => c.Category)
                    .FirstOrDefault(c => c.CountryId == id),
                ActiveSport = session.GetActiveSport(),
                ActiveGame = session.GetActiveGame(),
                ActiveCategory = session.GetActiveCategory()
            };
            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Add(CountryViewModel model)
        {
            model.Country = context.Countries
                .Include(c => c.Game)
                .Include(c => c.Sport)
                .Include(c => c.Category)
                .Where(c => c.CountryId == model.Country.CountryId)
                .FirstOrDefault();

            var session = new CountrySession(HttpContext.Session);
            var Countries = session.GetMyCountries();
            Countries.Add(model.Country);
            session.SetMyCountries(Countries);

            var cookies = new CountryCookies(HttpContext.Response.Cookies);
            cookies.SetMyCountryIds(Countries);

            TempData["message"] = $"{model.Country.Name} added to your favorites";

            return RedirectToAction("Index",
                new
                {
                    ActiveGame = session.GetActiveGame(),
                    ActiveSport = session.GetActiveSport(),
                    ActiveCategory = session.GetActiveCategory()
                });
        }
    }
}
