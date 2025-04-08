using BackEndSisVes.BackEndSisVesBO.OrderServiceOrderVehicles;
using BackEndSisVes.BackEndSisVesEntidades.OrderVehicleEntidades;
using Microsoft.AspNetCore.Mvc;

namespace BackEndSisVes.Controllers.OrdersControllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class OrdersController : Controller
    {
        private readonly OrderServiceOrderVehicles orderService;
        public OrdersController(OrderServiceOrderVehicles orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet("GetAllOrders")]
        public IActionResult GetAllOrders()
        {
            try
            {
                List<OrderVehicleRequest> response = orderService.GetAllOrdersOfVehicle();
                if (response.Count < 1 || response == null)
                {
                    return NotFound("There aren't orders yet");
                }
                else
                {
                    return Ok(response);
                }
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("InsertOrder")]
        public IActionResult InsertOrder([FromBody] InsertOrderVehicleRequest order)
        {
            try
            {
               bool respose = orderService.InsertOrderOfVehicle(order);
                if(respose)
                {
                    return Ok(new {message = "Inserted Successfully"});
                }
                else
                {
                    return Ok(new { message = "Error inserting order" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        
        [HttpPut("UpdateOrder")]
        public IActionResult UpdateOrder([FromBody] UpdateVehicleRequestorder order)
        {
            try
            {
               bool respose = orderService.UpdateOrderOfVehicle(order);
                if(respose)
                {
                    return Ok(new {message = "Inserted Successfully"});
                }
                else
                {
                    return Ok(new { message = "Error inserting order" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
