namespace RestCountries.Models.ViewModels
{
    public class CountryDetailsViewModel
    {
        public string? CommonName { get; set; }
        public string? OfficialName { get; set; }
        public string? Region { get; set; }
        public string[]? Capital { get; set; }
        public string[]? Languages { get; set; }
    }
}
