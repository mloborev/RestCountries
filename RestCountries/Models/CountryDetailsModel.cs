namespace RestCountries.Models
{
    public class CountryDetailsModel
    {
        public int CountryId { get; set; }
        public string Name { get; set; } = "";
        public string Region { get; set; } = "";
        public string Capital { get; set; } = "";
        public List<string> Languages { get; set; } = new List<string>(20);
    }
}
