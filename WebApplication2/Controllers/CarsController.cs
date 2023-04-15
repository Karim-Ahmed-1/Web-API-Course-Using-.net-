using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Filters;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        #region static list
        private static List<Car> cars = new List<Car> { };
        private ILogger<CarsController> _logger;
        private Request _req;
        #endregion

        public CarsController(ILogger<CarsController> logger,Request req)
        {
            _logger =logger;
            _req=req;

        }
        [HttpGet]
        public ActionResult<List<Car>> GetCars()
        {
            _logger.LogCritical("in Get all");
            //return Ok(cars);
            return cars;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Car> GetCarByID(int id)
        {
            Car? CarByID = cars.FirstOrDefault(x => x.Id == id);

            if (CarByID == null)
            {
                return NotFound();
            }
            //return Ok(CarByID);
            return CarByID;
        }

        [HttpPost]
        [Route("V1")]
        public ActionResult Addcar_V1(Car NewCar)
        {
            NewCar.Id = cars.Count() + 1;
            NewCar.type = "Gas";
            cars.Add(NewCar);
            return CreatedAtAction(actionName: nameof(GetCarByID),
                routeValues: new { id = NewCar.Id },
                new GeneralRespone { message = "The entity has been added successfully" });

        }

       
        [HttpPost]
        [Route("V2")]
        [ValidateTypeFilter]
        public ActionResult Addcar_V2(Car car)
        {
            car.Id = cars.Count() + 1;
            cars.Add(car);
            return CreatedAtAction(actionName: nameof(GetCarByID),
                routeValues: new { id = car.Id },
                new GeneralRespone { message = "The entity has been added successfully" });

        }
        [HttpPut]
        [Route("{id}")]
        public ActionResult Editcar(Car car, int id)
        {
            if (car.Id != id)
            {
                return BadRequest();
            }
            var carToEdit = cars.FirstOrDefault(x => x.Id == id);
            if (carToEdit == null) { return NotFound(); }
            carToEdit.name = car.name;
            carToEdit.model = car.model;
            carToEdit.ProductionDate = car.ProductionDate;

            return NoContent();

        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Deletecar(int id)
        {
            var carToDelete = cars.FirstOrDefault(x => x.Id == id);
            if (carToDelete == null) { return NotFound(); }
            cars.Remove(carToDelete);

            return NoContent();

        }

        [HttpGet]
        [Route("ReqCount")]
        public ActionResult GetCount() 
        {
            return Ok(_req.Count);
        }
    }
}
