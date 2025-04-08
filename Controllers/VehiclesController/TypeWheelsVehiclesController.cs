using BackEndSisVes.BackEndSisVesBO.OrderServiceVehicles;
using BackEndSisVes.BackEndSisVesEntidades.VehiclesEntidades;
using Microsoft.AspNetCore.Mvc;

namespace BackEndSisVes.Controllers.VehiclesController
{
    [ApiController]
    [Route("api/[controller]")]
    public class TypeWheelsVehiclesController : Controller
    {
        
        private readonly OrderServiceTypeWheelsVehicles orderServiceTypeWheelsVehicles;
        public TypeWheelsVehiclesController(OrderServiceTypeWheelsVehicles orderServiceTypeWheelsVehicles)
        {
            this.orderServiceTypeWheelsVehicles = orderServiceTypeWheelsVehicles;
        }

        [HttpGet("GetTypesWheels")]
        public IActionResult GetTypesWheels()
        {
            try
            {
                List<TypeWheelsVehicleRequest> result = orderServiceTypeWheelsVehicles.GetTypeWheelsVehicle();
                if (result == null || result.Count < 0)
                {
                    return NotFound("There aren't types of wheels");
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("InsertTypeWheelsVehicle")]
        public IActionResult InsertTypeWheelsVehicle([FromBody] TypeWheelsVehicleRequest request) 
        {
            
            try
            {
                bool response = orderServiceTypeWheelsVehicles.InsertTypeWheelVehicle(request);
                if(response)
                {
                    return Json(new {message = "Type Wheel inserted Successfully"});
                }
                {
                    return Json(new { message = "Error inserted type of wheel" });
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
                

            
        }
        
        [HttpPut("UpdateTypeWheelsVehicle")]
        public IActionResult UpdateTypeWheelsVehicle([FromBody] TypeWheelsVehicleRequest request) 
        {
            
            try
            {
                bool response = orderServiceTypeWheelsVehicles.UpdateTypeWheelVehicle(request);
                if(response)
                {
                    return Json(new {message = "Type Wheel updated Successfully"});
                }
                {
                    return Json(new { message = "Error updating type of wheel" });
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
                

            
        }
    }
}
