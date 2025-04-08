using BackEndSisVes.BackEndSisVesBO.OrderServiceDirecciones;
using BackEndSisVes.BackEndSisVesEntidades.DirectionsEntidades;
using Microsoft.AspNetCore.Mvc;

namespace BackEndSisVes.Controllers.DirectionsController
{
    [ApiController]
    [Route("api/[controller]")]
    public class SignalController : Controller
    {
        private readonly OrderServiceSignals orderServiceSignals;
        public SignalController(OrderServiceSignals orderServiceSignals)
        {
            this.orderServiceSignals = orderServiceSignals;
        }

        [HttpGet]
        public IActionResult GetAllSignals()
        {
            try
            {
                List<SignalRequest> signals = orderServiceSignals.getAllSignals();
                if(signals == null || signals.Count <1)
                {
                    return NotFound("There aren't signals");
                }
                else
                {
                    return Ok(signals);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("InsertSignalClient")]
        public IActionResult InsertCanton([FromBody] InsertSignalRequest signal)
        {
            try
            {
                bool isInserted = orderServiceSignals.InsertSignalClient(signal);
                if (isInserted)
                    return Ok(new { message = "Signal inserted successfully" });
                return BadRequest(new { message = "Failed to insert canton" });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateSignalClient")]
        public IActionResult UpdateCanton([FromBody] SignalRequest signal)
        {
            try
            {
                bool isUpdated = orderServiceSignals.updateSignalClient(signal);
                if (isUpdated)
                    return Ok(new { message = "Signal updated successfully" });
                return BadRequest(new { message = "Failed to update canton" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
