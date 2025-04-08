using BackEndSisVes.BackEndSisVesBO.OrderServiceVehicles;
using BackEndSisVes.BackEndSisVesEntidades.VehiclesEntidades;
using Microsoft.AspNetCore.Mvc;

namespace BackEndSisVes.Controllers.VehiclesController
{
    [ApiController]
    [Route("api/[controller]")]
    public class RodajeVehicleController : Controller
    {
        private readonly OrderServiceRodajeVehicle orderServiceRodaje;

        public RodajeVehicleController(OrderServiceRodajeVehicle orderServiceRodaje)
        {
            this.orderServiceRodaje = orderServiceRodaje;
        }

        [HttpPut("UpdateRodajeVehicle")]
        public IActionResult UpdateRodajeVehicle([FromBody] RodVehicleRequest rod)
        {
            try
            {
                bool response = orderServiceRodaje.UpdateRodajeVehicle(rod);
                if (response)
                {
                    return Json(new { message = "Rodaje of vehicle Updated Successfully" });
                }
                else
                {
                    return BadRequest("Error Updating Rodaje Vehicle");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
