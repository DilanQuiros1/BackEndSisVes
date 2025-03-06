using BackEndSisVes.BackEndSisVesBO.OrderServiceDirecciones;
using BackEndSisVes.BackEndSisVesEntidades.DirectionsEntidades;
using Microsoft.AspNetCore.Mvc;

namespace BackEndSisVes.Controllers.DirectionsController
{
    [ApiController]
    [Route("api/[controller]")]
    public class CantonController : Controller
    {
        private readonly OrderServiceCanton _orderServiceCanton;

        public CantonController(OrderServiceCanton orderServiceCanton)
        {
            _orderServiceCanton = orderServiceCanton;
        }

        [HttpGet("GetAllCantones")]
        public IActionResult GetAllCantones()
        {
            try
            {
                var cantones = _orderServiceCanton.GetCantones();

                if (cantones == null || cantones.Count == 0)
                {
                    return NotFound("No se encontraron Cantones.");
                }

                return Ok(cantones);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPost("InsertCanton")]
        public IActionResult InsertCanton([FromBody] CantonRequest canton)
        {
            bool isInserted = _orderServiceCanton.InsertCanton(canton);
            if (isInserted)
                return Ok(new { message = "Canton inserted successfully" });
            return BadRequest(new { message = "Failed to insert canton" });
        }

        [HttpPut("UpdateCanton")]
        public IActionResult UpdateCanton([FromBody] CantonRequest canton)
        {
            bool isUpdated = _orderServiceCanton.UpdateCanton(canton);
            if (isUpdated)
                return Ok(new { message = "Canton updated successfully" });
            return BadRequest(new { message = "Failed to update canton" });
        }

        [HttpGet("GetSession")]
        public IActionResult getSessionUser()
        {
            string ID = _orderServiceCanton.getSession();
            if(ID != null)
            {
                return Ok(new { ID });
            }
            else
            {
                return NotFound();
            }
           
        }

    }
}
