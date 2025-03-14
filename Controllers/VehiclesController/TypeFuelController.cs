using BackEndSisVes.BackEndSisVesBO.OrderServiceVehicles;
using BackEndSisVes.BackEndSisVesEntidades.VehiclesEntidades;
using Microsoft.AspNetCore.Mvc;

namespace BackEndSisVes.Controllers.VehiclesController
{
    [ApiController]
    [Route("api/[controller]")]
    public class TypeFuelController : Controller
    {
        private readonly OrderServiceTypeFuel typeFuel;

        public TypeFuelController(OrderServiceTypeFuel typeFuel)
        {
            this.typeFuel = typeFuel;
        }

        [HttpGet("GetTypeFuel")]
        public IActionResult GetTypeFuel()
        {
            try
            {
                List<TypeFuelRequest> result = typeFuel.getTypesFuel();
                if (result == null || result.Count <0)
                {
                    return NotFound("There aren't types of fuel");
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

        [HttpPost("InsertTypeFuel")]
        public IActionResult InsertTypeFuel([FromBody] TypeFuelRequest typeFuelRequest)
        {
            try
            {
                bool result = typeFuel.InsertTypeFuel(typeFuelRequest);
                if(result)
                {
                    return Ok(new {message = "Type Fuel Inserted successfully"});
                }
                else
                {
                    return BadRequest(new { message = "There is an error Inserted Type Fuel" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        
        [HttpPut("UpdateTypeFuel")]
        public IActionResult UpdateTypeFuel([FromBody] TypeFuelRequest typeFuelRequest)
        {
            try
            {
                bool result = typeFuel.UpdateTypeFuel(typeFuelRequest);
                if(result)
                {
                    return Ok(new {message = "Type Fuel Updated successfully"});
                }
                else
                {
                    return BadRequest(new { message = "There is an error Updating Type Fuel" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
