using Day2.BL;
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
        public ActionResult GetAll()
        {
            
            
        }
    }
}
