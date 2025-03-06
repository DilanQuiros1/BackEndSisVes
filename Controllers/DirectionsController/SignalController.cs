using BackEndSisVes.BackEndSisVesBO.OrderServiceDirecciones;
using BackEndSisVes.BackEndSisVesEntidades.DirectionsEntidades;
using Microsoft.AspNetCore.Mvc;

namespace BackEndSisVes.Controllers.DirectionsController
{
    public class SignalController : Controller
    {
        private readonly OrderServiceSignals orderServiceSignals;
        public SignalController(OrderServiceSignals orderServiceSignals)
        {
            this.orderServiceSignals = orderServiceSignals;
        }

        [HttpPost("InsertSignalClient")]
        public IActionResult InsertCanton([FromBody] SignalRequest signal)
        {
            bool isInserted = orderServiceSignals.InsertSignalClient(signal);
            if (isInserted)
                return Ok(new { message = "Signal inserted successfully" });
            return BadRequest(new { message = "Failed to insert canton" });
        }

        [HttpPut("UpdateSignalClient")]
        public IActionResult UpdateCanton([FromBody] SignalRequest signal)
        {
            bool isUpdated = orderServiceSignals.updateSignalClient(signal);
            if (isUpdated)
                return Ok(new { message = "Signal updated successfully" });
            return BadRequest(new { message = "Failed to update canton" });
        }
    }
}
