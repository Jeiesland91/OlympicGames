using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace OlympicGames.Models
{
    public class CountrySession
    {
        private const string CountriesKey = "mycountries";
        private const string CountKey = "countrycount";
        private const string GameKey = "game";
        private const string SportKey = "sport";
        private const string CategoryKey = "category";
        private const string NameKey = "name";

        private ISession session { get; set; }
        public CountrySession(ISession session)
        {
            this.session = session;
        }

        public void SetMyCountries(List<Country> countries)
        {
            session.SetObject(CountriesKey, countries);
            session.SetInt32(CountKey, countries.Count);
        }

        public List<Country> GetMyCountries() =>
            session.GetObject<List<Country>>(CountriesKey) ?? new List<Country>();
        public int? GetMyCountryCount() => session.GetInt32(CountKey);

        public void SetName(string userName = "friend")
        {
            session.SetString(NameKey, userName);
        }
        public string GetName() => session.GetString(NameKey);

        public void SetActiveGame(string game) =>
            session.SetString(GameKey, game);
        public string GetActiveGame() => session.GetString(GameKey);

        public void SetActiveSport(string sport) =>
            session.SetString(SportKey, sport);
        public string GetActiveSport() => session.GetString(SportKey);

        public void SetActiveCategory(string category) =>
            session.SetString(CategoryKey, category);
        public string GetActiveCategory() => session.GetString(CategoryKey);

        public void RemoveMyCountries()
        {
            session.Remove(CountriesKey);
            session.Remove(CountKey);
        }
    }
}
