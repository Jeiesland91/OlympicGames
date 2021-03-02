using System;
using System.Collections.Generic;

namespace OlympicGames.Models
{
    public class CountryListViewModel : CountryViewModel
    {
        public String UserName { get; set; }
        public List<Country> Countries { get; set; }

        // use full properties for Games, Sports and Categories 
        // so can add 'All' item at beginning
        private List<Game> games;
        public List<Game> Games
        {
            get => games;
            set
            {
                games = new List<Game> {
                    new Game { GameId = "all", Name = "All" }
                };
                games.AddRange(value);
            }
        }

        private List<Sport> sports;
        public List<Sport> Sports
        {
            get => sports;
            set
            {
                sports = new List<Sport> {
                    new Sport { SportId = "all", Name = "All" }
                };
                sports.AddRange(value);
            }
        }

        private List<Category> categories;
        public List<Category> Categories
        {
            get => categories;
            set
            {
                categories = new List<Category> {
                    new Category { CategoryId = "all", Name = "All" }
                };
                categories.AddRange(value);
            }
        }
        // methods to help view determine active link
        public string CheckActiveGame(string g) =>
            g.ToLower() == ActiveGame.ToLower() ? "active" : "";
        public string CheckActiveSport(string s) =>
            s.ToLower() == ActiveSport.ToLower() ? "active" : "";
        public string CheckActiveCategory(string c) =>
            c.ToLower() == ActiveCategory.ToLower() ? "active" : "";
    }
}
