using BackEndSisVes.BackEndSisVesBO.OrderServiceDirecciones;
using BackEndSisVes.BackEndSisVesEntidades.DirectionsEntidades;
using Microsoft.AspNetCore.Mvc;

namespace BackEndSisVes.Controllers.DirectionsController
{
    [ApiController]
    [Route("api/[controller]")]
    public class DirectionsController : Controller
    {
        private readonly OrderServiceDirections _orderServiceDirection;

        public DirectionsController(OrderServiceDirections orderServiceDirection)
        {
            _orderServiceDirection = orderServiceDirection;
        }


        [HttpPost("InsertDirectionClient")]
        public IActionResult InsertCanton([FromBody] DirectionsRequest direction)
        {
            bool isInserted = _orderServiceDirection.InsertDirection(direction);
            if (isInserted)
                return Ok(new { message = "Direction inserted successfully" });
            return BadRequest(new { message = "Failed to insert canton" });
        }

        [HttpPut("UpdateDirectionClient")]
        public IActionResult UpdateCanton([FromBody] DirectionsRequest direction)
        {
            bool isUpdated = _orderServiceDirection.updateDirection(direction);
            if (isUpdated)
                return Ok(new { message = "Direction updated successfully" });
            return BadRequest(new { message = "Failed to update canton" });
        }

    }
}
