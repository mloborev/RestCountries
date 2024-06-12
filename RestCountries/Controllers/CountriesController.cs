using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestCountries.Models;
using RestCountries.Models.ViewModels;
using System.Net;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace RestCountries.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController : ControllerBase
    {
        [HttpGet]
        public async Task<string> Get()
        {
            var responseList = new List<AllCountriesViewModel>(250);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://restcountries.com/v3.1/");
                var result = await client.GetAsync("all");
                var content = await result.Content.ReadAsStringAsync();
                var countriesList = JsonConvert.DeserializeObject<List<CountryDataApiModel>>(content);
                foreach (var item in countriesList)
                {
                    responseList.Add(new AllCountriesViewModel()
                    { 
                        CommonName = item.Name.Common, 
                        OfficialName = item.Name.Official, 
                        Capital = item.Capital
                    });
                }
                responseList = responseList.OrderBy(x => x.CommonName).ToList();
            }
            var response = JsonConvert.SerializeObject(responseList);
            
            return response;
        }

        [HttpGet("{name}")]
        public async Task<string> Get(string name)
        {
            var responseList = new List<CountryDetailsViewModel>(250);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://restcountries.com/v3.1/");
                var result = await client.GetAsync($"name/{name}");
                var content = await result.Content.ReadAsStringAsync();
                var countriesList = JsonConvert.DeserializeObject<List<CountryDataApiModel>>(content);

                foreach (var item in countriesList)
                {
                    var buffer = item.Languages.ToString();
                    MatchCollection matches = Regex.Matches(buffer, @"\b[\w']*\b");
                    List<string> languages = new List<string>(10);
                    for (int i = 0; i < matches.Count; i++)
                    {
                        var matchValueCharArray = matches[i].Value.ToCharArray();
                        if (matches[i].Value != "" && char.IsUpper(matchValueCharArray[0]))
                        {
                            languages.Add(matches[i].Value);
                        }
                    }
                    var languagesArray = languages.ToArray();

                    responseList.Add(new CountryDetailsViewModel()
                    { 
                        CommonName = item.Name.Common, 
                        OfficialName = item.Name.Official, 
                        Region = item.Region, 
                        Capital = item.Capital, 
                        Languages = languagesArray
                    });
                }
                responseList = responseList.OrderBy(x => x.CommonName).ToList();
            }
            var response = JsonConvert.SerializeObject(responseList);

            return response;
        }
    }
}
