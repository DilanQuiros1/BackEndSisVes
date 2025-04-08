using BackEndSisVes.BackEndSisVesBO.OrderServiceVehicles;
using BackEndSisVes.BackEndSisVesEntidades.VehiclesEntidades;
using Microsoft.AspNetCore.Mvc;

namespace BackEndSisVes.Controllers.VehiclesController
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeighVehicleController : Controller
    {
        private readonly OrderServiceWeighsVehicle orderServiceWeighsVehicle;
    
        public WeighVehicleController(OrderServiceWeighsVehicle orderServiceWeighsVehicle)
        {
            this.orderServiceWeighsVehicle = orderServiceWeighsVehicle;
        }

        [HttpGet("GetWeighsVehicle")]
        public IActionResult GetWeighsVehicle()
        {
            try
            {
                List<WeighVehicleRequest> result = orderServiceWeighsVehicle.GetWheighsVehicle();
                if (result.Count > 0 && result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound("There aren't weigh vehicles");
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        
        [HttpPut("UpdateWeighVehicle")]
        public IActionResult UpdateWeighVehicle(WeighVehicleRequest weighVehicle)
        {
            try
            {
                bool result = orderServiceWeighsVehicle.UpdateWeighVehicle(weighVehicle);
                if (result)
                {
                    return Ok(new {message="Updated successfully"});
                }
                else
                {
                    return NotFound("Error updating weight of vehicle");
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
