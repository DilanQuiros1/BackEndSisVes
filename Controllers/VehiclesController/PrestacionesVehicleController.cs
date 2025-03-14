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


        [HttpGet("GetPrestacionesVehicle")]
        public IActionResult GetPrestacionesVehicle()
        {
            try
            {
                List<PrestacionesVehiclesRequest> response = orderServicePrestaciones.GetPrestacionesVehicles();
                if (response != null || response.Count>0)
                {
                    return Ok(response);
                }
                else
                {
                    return NotFound(new { message = "Error Inserted Prestaciones" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("InsertPrestacionesVehicle")]
        public IActionResult InsertPrestacionesVehicle(PrestacionesVehiclesRequest prestaciones)
        {
            try
            {
                bool response = orderServicePrestaciones.InsertPrestacionesVehicle(prestaciones);
                if(response)
                {
                    return Json(new {message = "Prestacion Inserted succesfully"});
                }
                else
                {
                    return Json(new { message = "Error Inserted Prestaciones" });
                }
            }   
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdatePrestacionesVehicle")]
        public IActionResult UpdatePrestacionesVehicle(PrestacionesVehiclesRequest prestaciones)
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
