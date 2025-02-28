using BackEndSisVes.BackEndSisVesBO;
using Microsoft.AspNetCore.Mvc;

namespace BackEndSisVes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : Controller
    {
        private readonly OrderService _orderService;

        public ClientsController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllClients()
        {
            try
            {
                var clients = _orderService.GetClients();

                if (clients == null || clients.Count == 0)
                {
                    return NotFound("No se encontraron clientes.");
                }

                return Ok(clients);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

    }
}
