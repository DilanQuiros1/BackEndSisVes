using BackEndSisVes.BackEndSisVesBO.OrderServiceVehicles;
using BackEndSisVes.BackEndSisVesEntidades.VehiclesEntidades;
using Microsoft.AspNetCore.Mvc;

namespace BackEndSisVes.Controllers.VehiclesController
{
    [ApiController]
    [Route("api/[controller]")]
    public class ModelBrandVehicleController : Controller
    {
       private readonly OrderServiceModelBrandVehicle orderServiceModelBrandVehicle;
        public ModelBrandVehicleController(OrderServiceModelBrandVehicle orderServiceModelBrandVehicle)
        {
            this.orderServiceModelBrandVehicle = orderServiceModelBrandVehicle;
        }

        [HttpGet("GetModelVehicle")]
        public IActionResult GetModelVehicle()
        {
            try
            {
                List<ModelBrandVehicleRequest> result = orderServiceModelBrandVehicle.getModelVehicle();
                if (result == null || result.Count < 0)
                {
                    return NotFound("There aren't types of models");
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("InsertModelVehicle")]
        public IActionResult InsertModelVehicle([FromBody] ModelBrandVehicleRequest model)
        {
            try
            {
                bool result = orderServiceModelBrandVehicle.InsertModelVehicle(model);
                if (result)
                {
                    return Ok(new { message = "Model Inserted successfully" });
                }
                else
                {
                    return BadRequest(new { message = "There is an error Inserted Model" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("UpdateModelVehicle")]
        public IActionResult UpdateModelVehicle([FromBody] ModelBrandVehicleRequest model)
        {
            try
            {
                bool result = orderServiceModelBrandVehicle.UpdateModelVehicle(model);
                if (result)
                {
                    return Ok(new { message = "Model Updated successfully" });
                }
                else
                {
                    return BadRequest(new { message = "There is an error Updating Model" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}
