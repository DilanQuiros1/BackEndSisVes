using BackEndSisVes.BackEndSisVesBO.OrderServiceClients;
using BackEndSisVes.BackEndSisVesEntidades.ClientsEntidades;
using Microsoft.AspNetCore.Mvc;

namespace BackEndSisVes.Controllers.ClientsController
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {

        private readonly OrderServiceContacts _orderService;

        public ContactsController(OrderServiceContacts orderService)
        {
            this._orderService = orderService;
        }


        [HttpPost("InsertContact")]
        public IActionResult InsertContact([FromBody] ContactsRequest contact)
        {
            try
            {
                bool result = _orderService.InsertContact(contact);
                if (result)
                {
                    return Ok(new { message = "Contact inserted successfully" });
                }
                else
                {
                    return BadRequest(new { message = "Failed to insert contact" });

                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPut("UpdateContactClient")]
        public IActionResult UpdateContactClient([FromBody] ContactsRequest contact)
        {
            try
            {
                bool result = _orderService.UpdateContact(contact);
                if (result)
                {
                    return Ok(new { message = "Contact updated successfully" });
                }
                else
                {
                    return BadRequest(new { message = "Failed to update contact" });

                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

    }
}
