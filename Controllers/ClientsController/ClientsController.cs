using BackEndSisVes.BackEndSisVesBO.OrderServiceClients;
using BackEndSisVes.BackEndSisVesEntidades.ClientsEntidades;
using Microsoft.AspNetCore.Mvc;

namespace BackEndSisVes.Controllers.ClientsController
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : Controller
    {
        private readonly OrderServiceClients _orderService;

        public ClientsController(OrderServiceClients orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("GetAllClients")]
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

        [HttpPost("InsertClient")]
        public IActionResult InsertClient([FromBody] ClientesRequest clients)
        {
            try
            {
                bool result = _orderService.insertClient(clients);
                if(result)
                {
                    return Ok(new { message = "Client inserted successfully" });
                }
                else
                {
                    return BadRequest(new { message = "Failed to insert Client" });

                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

 

    }
}
