using IntroToAPIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IntroToAPIs
{
    public class SWAPIService
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<Person> GetPersonAsync(string url)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                Person person = await response.Content.ReadAsAsync<Person>();
                return person;  
            }

            return null;
        }

        public async Task<Vehicle> GetVehicleAsync(string url)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                Vehicle vehicle = await response.Content.ReadAsAsync<Vehicle>();
                return vehicle;
            }

            return null;
        }

        public async Task<T> GetAsync<T>(string url)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<T>();
            }

            return default;
        }

        public async Task<SearchResult<Person>> GetPersonSearchAsync(string query)
        {
            HttpResponseMessage response = await _httpClient.GetAsync("https://swapi.dev/api/people/?search=" + query);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<SearchResult<Person>>();
            }

            return null;
        }

        public async Task<SearchResult<T>> GetSearchAsync<T>(string category, string query)
        {
            HttpResponseMessage response = await _httpClient.GetAsync("https://swapi.dev/api/" + category + "/?search=" + query);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<SearchResult<T>>();
            }

            return default;
        }

        public async Task<SearchResult<Vehicle>> GetVehicleSearch(string query)
        {
            return await GetSearchAsync<Vehicle>("vehicles", query);
        }
    }
}
