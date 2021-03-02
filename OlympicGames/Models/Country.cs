namespace OlympicGames.Models
{
    public class Country
    {
        public string CountryId { get; set; }
        public string Name { get; set; }
        public string GameId { get; set; }
        public Game Game { get; set; }
        public string SportId { get; set; }
        public Sport Sport { get; set; }
        public string CategoryId { get; set; }
        public Category Category { get; set; }
        public string FlagImage { get; set; }
    }
}
