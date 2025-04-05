using BackEndSisVes.BackEndSisVesBO.OrderServiceVehicles;
using BackEndSisVes.BackEndSisVesEntidades.VehiclesEntidades;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BackEndSisVes.Controllers.VehiclesController
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrestacionesVehicleController : Controller
    {
        private readonly OrderServicePrestacionesVehicle orderServicePrestaciones;
        public PrestacionesVehicleController(OrderServicePrestacionesVehicle orderServicePrestaciones)
        {
            this.orderServicePrestaciones = orderServicePrestaciones;
        }


        

       
        [HttpPut("UpdatePrestacionesVehicle")]
        public IActionResult UpdatePrestacionesVehicle([FromBody] PrestacionesVehiclesRequest prestaciones)
        {
            try
            {
                bool response = orderServicePrestaciones.UpdatePrestacionesVehicle(prestaciones);
                if (response)
                {
                    return Json(new { message = "Prestacion Updated succesfully" });
                }
                else
                {
                    return Json(new { message = "Error Updating Prestaciones" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
