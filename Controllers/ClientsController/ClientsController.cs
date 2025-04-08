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
                var clients = _orderService.GetClients("");

                if (clients == null || clients.Count == 0)
                {
                    return NotFound("No se encontraron clientes.");
                }

                var respose = clients.Select( c=> new
                {
                    ID_Client = c.Item1.CLI_Identificacion,
                    Name_Client = c.Item1.CLI_Nombre,
                    LastName_Client = c.Item1.CLI_Apellidos,
                    TypeID_Client = c.Item2.TIPIDE_Tipo_identificacion
                }).ToList();

               

                return Ok(respose);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("GetClientByID")]
        public IActionResult GetClientByID(string CLI_Identificacion)
        {
            try
            {
                var clients = _orderService.GetClients(CLI_Identificacion);

                if (clients == null || clients.Count == 0)
                {
                    return NotFound("No se encontro el cliente.");
                }

                var respose = clients.Select(c => new
                {
                    ID_Client = c.Item1.CLI_Identificacion,
                    Name_Client = c.Item1.CLI_Nombre,
                    LastName_Client = c.Item1.CLI_Apellidos,
                    TypeID_Client = c.Item2.TIPIDE_Tipo_identificacion
                }).ToList();



                return Ok(respose);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("GetAllContactsClients")]
        public IActionResult GetAllContactsClients(int CLI_Identificacion)
        {
            try
            {
                if (CLI_Identificacion <= 0)
                {
                    return BadRequest("The CLI_ID must be valid");
                }

                var clients = _orderService.GetContactsClient(CLI_Identificacion);

                if (clients == null || clients.Count == 0)
                {
                    return NotFound("There aren't any Contacts of a Client");
                }

                var response = clients.Select(c => new
                {
                    Contacto = c.Item1.CON_Contacto,
                    TipoContacto = c.Item2.TIPCON_Tipo_Contacto
                }).ToList();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("GetAllDirectionsClients")]
        public IActionResult GetAllDirectionsClients(int CLI_ID)
        {
            try
            {
                if (CLI_ID <= 0)
                {
                    return BadRequest("The CLI_ID must be valid");
                }

                var clients = _orderService.GetDirectionClient(CLI_ID);

                if (clients == null || clients.Count == 0)
                {
                    return NotFound("There aren't any directions of a Client");
                }


                var response = clients.Select(c => new
                {
                    Distrito = c.Item1.DIS_Distrito,
                    Canton = c.Item2.CAN_Canton,
                    Provincia = c.Item3.PRO_Nombre
                });

                return Ok(response);
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
        
        [HttpPut("UpdateClient")]
        public IActionResult UpdateClient([FromBody] UpdateClientesRequest clients)
        {
            try
            {
                bool result = _orderService.UpdateClient(clients);
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
        
        [HttpPut("deactivateClient")]
        public IActionResult deactivateClient(int CLI_Identificacion)
        {
            try
            {
                if(CLI_Identificacion <= 1)
                {
                    return BadRequest(new { message = "Enter a valid Identification" });
                }
                bool result = _orderService.deactivateClient(CLI_Identificacion);
                if(result)
                {
                    return Ok(new { message = "Client deactivate successfully" });
                }
                else
                {
                    return BadRequest(new { message = "Failed to deactivate Client" });

                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

 

    }
}
