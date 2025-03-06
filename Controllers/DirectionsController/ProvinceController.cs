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

        [HttpPost("InsertProvince")]
        public IActionResult InsertCanton([FromBody] ProvinciaRequest province)
        {
            bool isInserted = orderServiceProvincia.InsertProvince(province);
            if (isInserted)
                return Ok(new { message = "Province inserted successfully" });
            return BadRequest(new { message = "Failed to insert canton" });
        }

        [HttpPut("UpdateProvince")]
        public IActionResult UpdateCanton([FromBody] ProvinciaRequest province)
        {
            bool isUpdated = orderServiceProvincia.updateProvince(province);
            if (isUpdated)
                return Ok(new { message = "Province updated successfully" });
            return BadRequest(new { message = "Failed to update canton" });
        }
    }
}
