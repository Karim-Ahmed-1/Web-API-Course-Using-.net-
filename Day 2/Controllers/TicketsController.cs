using Day2.BL;
using Day2.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Day_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private ITicketManager _ticketmanager;

        public TicketsController(ITicketManager ticketManager)
        {
            _ticketmanager = ticketManager;
        }

        [HttpGet]
        public ActionResult<List<Ticket>> getall()
        {
            var tickets = _ticketmanager.Getall();
            return tickets;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Ticket?> GetById(int id)
        {
            var ticket = _ticketmanager.GetByID(id);
            return ticket;
        }

        [HttpPost]
        public ActionResult Delete(Ticket entity)
        {
            _ticketmanager.Delete(entity);
            _ticketmanager.SaveChanges();
            return NoContent();
        }

        [HttpPut]
        public ActionResult Update(Ticket entity)
        {
            if (entity == null) { return BadRequest(); }
            var TicketToEdit = _ticketmanager.GetByID(entity.Id);
            if (TicketToEdit == null) { return NotFound(); }
            TicketToEdit.Title = entity.Title;
            TicketToEdit.Description = entity.Title;
            TicketToEdit.department = entity.department;
            TicketToEdit.Developers = entity.Developers;
            _ticketmanager.SaveChanges();
            return NoContent();

        }

        [HttpPost]
        public ActionResult Add(Ticket entity)
        {
            _ticketmanager.AddTicket(entity);
            _ticketmanager.SaveChanges();
            return CreatedAtAction(actionName: "GetById",routeValues: new {id=entity.Id}, "The entity has been added successfully");
        }
    }
}
