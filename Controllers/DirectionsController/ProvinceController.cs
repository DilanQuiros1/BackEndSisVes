using BackEndSisVes.BackEndSisVesBO.OrderServiceDirecciones;
using BackEndSisVes.BackEndSisVesEntidades.DirectionsEntidades;
using Microsoft.AspNetCore.Mvc;

namespace BackEndSisVes.Controllers.DirectionsController
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProvinceController : Controller
    {
       private readonly OrderServiceProvincia orderServiceProvincia;
        public ProvinceController(OrderServiceProvincia orderServiceProvincia)
        {
            this.orderServiceProvincia = orderServiceProvincia;
        }

        [HttpGet("GetAlProvinces")]
        public IActionResult GetAllCantones()
        {
            try
            {
                var cantones = orderServiceProvincia.GetAllProvinces();

                if (cantones == null || cantones.Count == 0)
                {
                    return NotFound("No se encontraron Provincias.");
                }

                return Ok(cantones);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

    }
}
