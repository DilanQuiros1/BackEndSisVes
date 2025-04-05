using BackEndSisVes.BackEndSisVesBO.OrderServiceDirecciones;
using BackEndSisVes.BackEndSisVesEntidades.DirectionsEntidades;
using Microsoft.AspNetCore.Mvc;

namespace BackEndSisVes.Controllers.DirectionsController
{
    [ApiController]
    [Route("api/[controller]")]
    public class DistritoController : Controller
    {
        private readonly OrderServiceDistrito orderServiceDistrito;
        public DistritoController(OrderServiceDistrito ServiceDistrito)
        {
            orderServiceDistrito = ServiceDistrito;
        }

        [HttpGet("GetAllDistritos")]
        public IActionResult GetAllCantones()
        {
            try
            {
                var distritos = orderServiceDistrito.GetAllDistritos();
                if (distritos == null || distritos.Count==0)
                {
                    return NotFound("No se encontraron Distritos");
                }
                return Ok(distritos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

       

    }
}
