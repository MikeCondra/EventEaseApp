using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using EventEaseApp.Models;

namespace EventEaseApp.Services
{
    public class EventService
    {
        private readonly HttpClient _httpClient;

        public EventService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

         
        public async Task<List<Event>?> LoadEventsAsync()
        {
            // XXX
            return await _httpClient.GetFromJsonAsync<List<Event>>("Event");
            //return await _httpClient.GetFromJsonAsync<List<Event>>("sample-data/events.json");
        }
        

        public async Task SaveEventsAsync(List<Event> events)
        {
            await _httpClient.PostAsJsonAsync("Event", events);
        }

        public async Task<Event?> GetEventByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Event>($"Event/{id}");
        }
    }
}