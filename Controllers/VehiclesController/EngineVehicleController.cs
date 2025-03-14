using BackEndSisVes.BackEndSisVesBO.OrderServiceVehicles;
using BackEndSisVes.BackEndSisVesEntidades.VehiclesEntidades;
using Microsoft.AspNetCore.Mvc;

namespace BackEndSisVes.Controllers.VehiclesController
{
    [ApiController]
    [Route("api/[controller]")]
    public class EngineVehicleController : Controller
    {
       private readonly OrderServiceEngineVehicle orderServiceEngineVehicle;
        public EngineVehicleController(OrderServiceEngineVehicle orderServiceEngineVehicle)
        {
            this.orderServiceEngineVehicle = orderServiceEngineVehicle;
        }

        [HttpGet("GetEngineVehicles")]
        public IActionResult GetEngineVehicles()
        {
            try
            {
                List<EngineVehicleRequest> result = orderServiceEngineVehicle.getEngineVehicle();
                if(result == null || result.Count < 0)
                {
                    return NotFound(new {message = "There aren't engines"});
                }
                else
                {
                    return Ok(result);
                }

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("InsertEngineVehicle")]
        public IActionResult InsertEngineVehicle([FromBody] EngineVehicleRequest engine)
        {
            try
            {
                bool result = orderServiceEngineVehicle.InsertEngineVehicle(engine);
                if (result)
                {
                    return Json(new { message = "Engine Inserted Successfully" });
                }
                else
                {
                    return Json(new { message = "Error Inserted Engine" });
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateEngineVehicle")]
        public IActionResult UpdateEngineVehicle([FromBody] EngineVehicleRequest engine)
        {
            try
            {
                bool result = orderServiceEngineVehicle.UpdateEngineVehicle(engine);
                if (result)
                {
                    return Json(new { message = "Engine Updated Successfully" });
                }
                else
                {
                    return Json(new { message = "Error Updated Engine" });
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
