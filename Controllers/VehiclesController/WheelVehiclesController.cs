using BackEndSisVes.BackEndSisVesBO.OrderServiceVehicles;
using BackEndSisVes.BackEndSisVesEntidades.VehiclesEntidades;
using Microsoft.AspNetCore.Mvc;

namespace BackEndSisVes.Controllers.VehiclesController
{
    [ApiController]
    [Route("api/[controller]")]
    public class WheelVehiclesController : Controller
    {
        private readonly OrderServiceWheelVehicles orderServiceWheelVehicles;

        public WheelVehiclesController(OrderServiceWheelVehicles orderServiceWheelVehicles)
        {
            this.orderServiceWheelVehicles = orderServiceWheelVehicles;
        }

        [HttpGet("GetWheelsVehicles")]
        public IActionResult GetWheelsVehicles()
        {
            try
            {
                List<WheelsVehiclesRequest> response = orderServiceWheelVehicles.GetWheelsVehicles();
                if (response != null && response.Count > 0)
                {
                    return Ok(response);
                }
                else
                {
                    return NotFound("There aren't wheels of vehicles");
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("InsertWheelVehicles")]
        public IActionResult InsertWheelVehicles([FromBody] WheelsVehiclesRequest wheels)
        {
            try
            {
                bool response = orderServiceWheelVehicles.InsertWheelVehicles(wheels);
                if(response)
                {
                    return Json(new { message = "Wheel of vehicle Inserted Successfully "+response});
                }
                else
                {
                    return BadRequest("Error inserted Wheel of vehicle");
                }    
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
                
        }

    }
}
