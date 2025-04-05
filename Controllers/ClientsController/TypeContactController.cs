using BackEndSisVes.BackEndSisVesBO.OrderServiceClients;
using BackEndSisVes.BackEndSisVesEntidades.ClientsEntidades;
using Microsoft.AspNetCore.Mvc;

namespace BackEndSisVes.Controllers.ClientsController
{
    [ApiController]
    [Route("api/[controller]")]
    public class TypeContactController : Controller
    {

        private readonly OrderServiceTypeContacs _orderService;

        public TypeContactController(OrderServiceTypeContacs orderService)
        {
            this._orderService = orderService;
        }

        [HttpGet("GetAllTypeContacts")]
        public IActionResult GetAllTypeContacts()
        {
            try
            {
                var typecontacts = _orderService.GetAllTypeContacts();

                if (typecontacts == null || typecontacts.Count == 0)
                {
                    return NotFound("No se encontraron los tipos de contacto.");
                }

                return Ok(typecontacts); // <-- Corrección: devolver typecontacts, no contacts
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPost("InsertTypeContact")]
        public IActionResult InsertTypeContact([FromBody] TypeContactRequest typecontact)
        {
            try
            {
                bool result = _orderService.InsertTypeContact(typecontact);
                if (result)
                {
                    return Ok(new { message = "Type Contact inserted successfully" });
                }
                else
                {
                    return BadRequest(new { message = "Failed to insert type contact" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

    }
}
