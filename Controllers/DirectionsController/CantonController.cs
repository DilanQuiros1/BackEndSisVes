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

       

    }
}
