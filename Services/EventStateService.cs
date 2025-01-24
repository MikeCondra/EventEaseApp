using System.Collections.Generic;
using System.Threading.Tasks;
using EventEaseApp.Models;

namespace EventEaseApp.Services
{
    public class EventStateService
    {
        private List<Event> events = new List<Event>();

        public List<Event> Events => events;

         
        public async Task LoadEventsAsync(EventService eventService)
        {
            // do nothing; start empty
            // events = await eventService.LoadEventsAsync();
            await Task.CompletedTask;
        }
        

        public Event? GetEventById(int id)
        {
            return events.Find(e => e.Id == id);
        }
    }
}