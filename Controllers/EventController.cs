using System;
using System.Collections.Generic;
using EventEaseApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventEaseApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
    {
        private static List<Event> events;

        static EventController()
        {
            events = new List<Event>
            {
                new Event { Id = 1, Name = "Event 1", Location = "Location 1", Date = new DateTime(2023, 1, 1), Details = "Details for Event 1" },
                new Event { Id = 2, Name = "Event 2", Location = "Location 2", Date = new DateTime(2023, 2, 1), Details = "Details for Event 2" },
                new Event { Id = 3, Name = "Event 3", Location = "Location 3", Date = new DateTime(2023, 3, 1), Details = "Details for Event 3" }
            };
        }

        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return events;
        }

        [HttpGet("{id}")]
        public ActionResult<Event> Get(int id)
        {
            var eventItem = events.Find(e => e.Id == id);
            if (eventItem == null)
            {
                return NotFound();
            }
            return eventItem;
        }

        [HttpPost]
        public ActionResult<Event> Post(Event newEvent)
        {
            newEvent.Id = events.Count > 0 ? events[^1].Id + 1 : 1;
            events.Add(newEvent);
            return CreatedAtAction(nameof(Get), new { id = newEvent.Id }, newEvent);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Event updatedEvent)
        {
            var eventItem = events.Find(e => e.Id == id);
            if (eventItem == null)
            {
                return NotFound();
            }

            eventItem.Name = updatedEvent.Name;
            eventItem.Location = updatedEvent.Location;
            eventItem.Date = updatedEvent.Date;
            eventItem.Details = updatedEvent.Details;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var eventItem = events.Find(e => e.Id == id);
            if (eventItem == null)
            {
                return NotFound();
            }

            events.Remove(eventItem);
            return NoContent();
        }
    }
}