using Microsoft.OpenApi.Services;
using System.Text.RegularExpressions;

namespace RestCountries.Models
{
    public class CountryDataApiModel
    {
        public Name Name { get; set; }
        /*public object? TId { get; set; }
        public string? Cca2 { get; set; }
        public string? Ccn3 { get; set; }
        public string? Cca3 { get; set; }
        public bool Independent { get; set; }
        public string? Status { get; set; }
        public bool UnMember { get; set; }
        public object Currencies { get; set; }
        public object Idd { get; set; }*/
        public string[] Capital { get; set; }
        //public object AltSpellings { get; set; }
        public string? Region { get; set; }
        //public string? Subregion { get; set; }
        public object Languages { get; set; }
        /*public object Translations { get; set; }
        public object LatIng { get; set; }
        public bool Landlocked { get; set; }
        public double Area { get; set; }
        public object Demonyms { get; set; }
        public string? Flag { get; set; }
        public object Maps { get; set; }
        public int Population { get; set; }
        public object Car { get; set; }
        public object Timezones { get; set; }
        public object Continents { get; set; }
        public object Flags { get; set; }
        public object coatOfArms { get; set; }
        public string? StartOfWeek { get; set; }
        public object CapitalInfo { get; set; }
        public object PostalCode { get; set; }*/
    }

    public class Name
    {
        public string? Common { get; set; }
        public string? Official { get; set; }
        public object NativeName { get; set; }
    }
}
